
using Zoo.BLL.DTOs;
using Zoo.BLL.DTOs.Owners;

namespace Zoo.BLL.Services.Interfaces;

public interface IOwnerService
{
    Task<PagedResult<OwnerReadDto>> GetPagedAsync(OwnerQueryParameters parameters, CancellationToken cancellationToken = default);
    Task<IEnumerable<OwnerReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<OwnerReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<OwnerReadDto> CreateAsync(OwnerCreateDto dto, CancellationToken cancellationToken = default);
    Task<OwnerReadDto> UpdateAsync(int id, OwnerUpdateDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
