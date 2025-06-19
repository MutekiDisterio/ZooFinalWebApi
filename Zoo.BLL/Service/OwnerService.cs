using Mapster;
using Microsoft.EntityFrameworkCore;
using Zoo.BLL.DTOs.Owners;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;
using Zoo.BLL.DTOs;
using Zoo.BLL.Exceptions; 

namespace Zoo.BLL.Services
{
    public class OwnerQueryParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? OrderBy { get; set; }
        public string? Name { get; set; }
    }

    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<OwnerReadDto>> GetPagedAsync(OwnerQueryParameters parameters, CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.Owners.GetAllQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.Name))
                query = query.Where(o => o.Name.Contains(parameters.Name));

            query = parameters.OrderBy?.ToLower() switch
            {
                "name" => query.OrderBy(o => o.Name),
                "name_desc" => query.OrderByDescending(o => o.Name),
                "id" => query.OrderBy(o => o.Id),
                "id_desc" => query.OrderByDescending(o => o.Id),
                _ => query.OrderBy(o => o.Id),
            };

            var totalCount = await query.CountAsync(cancellationToken);

            var entities = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync(cancellationToken);

            var dtos = entities.Adapt<List<OwnerReadDto>>();

            return new PagedResult<OwnerReadDto>
            {
                Items = dtos,
                TotalCount = totalCount,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize
            };
        }

        public async Task<IEnumerable<OwnerReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var owners = await _unitOfWork.Owners.GetAllAsync(cancellationToken);
            return owners.Adapt<IEnumerable<OwnerReadDto>>();
        }

        public async Task<OwnerReadDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var owner = await _unitOfWork.Owners.GetByIdAsync(id);
            if (owner == null)
                throw new NotFoundException($"Owner with ID={id} not found.");

            return owner.Adapt<OwnerReadDto>();
        }

        public async Task<OwnerReadDto> CreateAsync(OwnerCreateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = dto.Adapt<Owner>();
            await _unitOfWork.Owners.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Adapt<OwnerReadDto>();
        }

        public async Task<OwnerReadDto> UpdateAsync(int id, OwnerUpdateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Owners.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"Owner with ID={id} not found.");

            dto.Adapt(entity);
            await _unitOfWork.Owners.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();

            return entity.Adapt<OwnerReadDto>();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Owners.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"Owner with ID={id} not found.");

            await _unitOfWork.Owners.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
