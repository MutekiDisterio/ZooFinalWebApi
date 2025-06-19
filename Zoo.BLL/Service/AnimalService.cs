using Mapster;
using Microsoft.EntityFrameworkCore;
using Zoo.BLL.DTOs;
using Zoo.BLL.DTOs.Animals;
using Zoo.BLL.DTOs.AnimalsCages;
using Zoo.BLL.DTOs.AnimalTypes;
using Zoo.BLL.DTOs.Cages;
using Zoo.BLL.DTOs.Owners;
using Zoo.BLL.DTOs.Volunteers;
using Zoo.BLL.DTOs.VolunteersDepartment;
using Zoo.BLL.Exceptions;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.Entity.HelpModels;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<PagedResult<AnimalReadDto>> GetPagedAsync(AnimalQueryParameters parameters, CancellationToken ct = default)
        {
            var query = _unitOfWork.Animals.GetAllQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.Name))
                query = query.Where(a => a.Name.Contains(parameters.Name));

            if (parameters.AnimalTypeId.HasValue)
                query = query.Where(a => a.AnimalTypeId == parameters.AnimalTypeId);

            query = parameters.OrderBy?.ToLower() switch
            {
                "name" => query.OrderBy(a => a.Name),
                "name_desc" => query.OrderByDescending(a => a.Name),
                "id" => query.OrderBy(a => a.Id),
                "id_desc" => query.OrderByDescending(a => a.Id),
                _ => query.OrderBy(a => a.Id),
            };

            var totalCount = await query.CountAsync(ct);

            var entities = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync(ct);

            var dtos = entities.Adapt<List<AnimalReadDto>>();

            return new PagedResult<AnimalReadDto>
            {
                Items = dtos,
                TotalCount = totalCount,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize
            };
        }

        public async Task<IEnumerable<AnimalReadDto>> GetAllAsync(CancellationToken ct = default)
        {
            var animals = await _unitOfWork.Animals.GetAllAsync(ct);
            return animals.Adapt<IEnumerable<AnimalReadDto>>();
        }

        public async Task<AnimalReadDto> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Animals.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"Animal with ID={id} not found");
            return entity.Adapt<AnimalReadDto>();
        }

        public async Task<AnimalReadDto> CreateAsync(AnimalCreateDto dto, CancellationToken ct = default)
        {
            var entity = dto.Adapt<Animal>();
            await _unitOfWork.Animals.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Adapt<AnimalReadDto>();
        }

        public async Task<AnimalReadDto> UpdateAsync(int id, AnimalUpdateDto dto, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Animals.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"Animal with ID={id} not found");

            dto.Adapt(entity);
            await _unitOfWork.Animals.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();

            return entity.Adapt<AnimalReadDto>();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Animals.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"Animal with ID={id} not found");

            await _unitOfWork.Animals.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}