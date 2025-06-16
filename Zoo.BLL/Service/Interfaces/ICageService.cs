
using Zoo.BLL.DTOs.Cages;

namespace Zoo.BLL.Services.Interfaces;

public interface ICageService
{
    Task<IEnumerable<CageReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CageReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CageReadDto> CreateAsync(CageCreateDto dto, CancellationToken cancellationToken = default);
    Task<CageReadDto> UpdateAsync(int id, CageUpdateDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
