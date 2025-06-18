using Mapster;
using Zoo.BLL.DTOs;
using Microsoft.EntityFrameworkCore;
using Zoo.BLL.DTOs.Animals;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.Entity.HelpModels;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class AnimalService : IAnimalService
{
    private readonly IUnitOfWork _unitOfWork;

    public AnimalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResult<AnimalReadDto>> GetPagedAsync(AnimalQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        var query = _unitOfWork.Animals.GetAllQueryable();

       
        if (!string.IsNullOrWhiteSpace(parameters.Name))
            query = query.Where(a => a.Name.Contains(parameters.Name));

        if (parameters.AnimalTypeId.HasValue)
            query = query.Where(a => a.AnimalTypeId == parameters.AnimalTypeId.Value);

      
        query = parameters.OrderBy?.ToLower() switch
        {
            "name" => query.OrderBy(a => a.Name),
            "name_desc" => query.OrderByDescending(a => a.Name),
            "id" => query.OrderBy(a => a.Id),
            "id_desc" => query.OrderByDescending(a => a.Id),
            _ => query.OrderBy(a => a.Id),
        };

        var totalCount = await query.CountAsync(cancellationToken);

        var entities = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync(cancellationToken);

        var dtos = entities.Adapt<List<AnimalReadDto>>();

        return new PagedResult<AnimalReadDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            PageNumber = parameters.PageNumber,
            PageSize = parameters.PageSize
        };
    }

    public async Task<IEnumerable<AnimalReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var animals = await _unitOfWork.Animals.GetAllAsync(cancellationToken);
        return animals.Adapt<IEnumerable<AnimalReadDto>>();
    }

    public async Task<AnimalReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Animals.GetByIdAsync(id);
        return entity is null ? null : entity.Adapt<AnimalReadDto>();
    }

    public async Task<AnimalReadDto> CreateAsync(AnimalCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<Animal>();
        await _unitOfWork.Animals.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return entity.Adapt<AnimalReadDto>();
    }

    public async Task<AnimalReadDto> UpdateAsync(int id, AnimalUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Animals.GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Animal with ID={id} not found");

        dto.Adapt(entity);
        await _unitOfWork.Animals.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return entity.Adapt<AnimalReadDto>();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Animals.GetByIdAsync(id);
        if (entity == null) return false;

        await _unitOfWork.Animals.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
