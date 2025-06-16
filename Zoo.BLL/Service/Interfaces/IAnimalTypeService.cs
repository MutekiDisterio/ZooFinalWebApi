
using Zoo.BLL.DTOs.AnimalTypes;

namespace Zoo.BLL.Services.Interfaces;

public interface IAnimalTypeService
{
    Task<IEnumerable<AnimalTypeReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AnimalTypeReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<AnimalTypeReadDto> CreateAsync(AnimalTypeCreateDto dto, CancellationToken cancellationToken = default);
    Task<AnimalTypeReadDto> UpdateAsync(int id, AnimalTypeUpdateDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
