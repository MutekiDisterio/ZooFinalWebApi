using Mapster;
using Microsoft.EntityFrameworkCore;
using Zoo.BLL.DTOs.Volunteers;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;
using Zoo.BLL.DTOs;

namespace Zoo.BLL.Services;

public class VolunteerQueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public string? OrderBy { get; set; }
    public string? Name { get; set; }
}

public class VolunteerService : IVolunteerService
{
    private readonly IUnitOfWork _unitOfWork;

    public VolunteerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResult<VolunteerReadDto>> GetPagedAsync(VolunteerQueryParameters parameters, CancellationToken cancellationToken = default)
    {
        var query = _unitOfWork.Volunteers.GetAllQueryable();

        if (!string.IsNullOrWhiteSpace(parameters.Name))
            query = query.Where(v => v.Name.Contains(parameters.Name));

        query = parameters.OrderBy?.ToLower() switch
        {
            "name" => query.OrderBy(v => v.Name),
            "name_desc" => query.OrderByDescending(v => v.Name),
            "id" => query.OrderBy(v => v.Id),
            "id_desc" => query.OrderByDescending(v => v.Id),
            _ => query.OrderBy(v => v.Id),
        };

        var totalCount = await query.CountAsync(cancellationToken);

        var entities = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync(cancellationToken);

        var dtos = entities.Adapt<List<VolunteerReadDto>>();

        return new PagedResult<VolunteerReadDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            PageNumber = parameters.PageNumber,
            PageSize = parameters.PageSize
        };
    }

    public async Task<IEnumerable<VolunteerReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var volunteers = await _unitOfWork.Volunteers.GetAllAsync(cancellationToken);
        return volunteers.Adapt<IEnumerable<VolunteerReadDto>>();
    }

    public async Task<VolunteerReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Volunteers.GetByIdAsync(id);
        return entity is null ? null : entity.Adapt<VolunteerReadDto>();
    }

    public async Task<VolunteerReadDto> CreateAsync(VolunteerCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<Volunteer>();
        await _unitOfWork.Volunteers.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return entity.Adapt<VolunteerReadDto>();
    }

    public async Task<VolunteerReadDto> UpdateAsync(int id, VolunteerUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Volunteers.GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Volunteer with ID={id} not found");

        dto.Adapt(entity);
        await _unitOfWork.Volunteers.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return entity.Adapt<VolunteerReadDto>();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Volunteers.GetByIdAsync(id);
        if (entity == null) return false;

        await _unitOfWork.Volunteers.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
