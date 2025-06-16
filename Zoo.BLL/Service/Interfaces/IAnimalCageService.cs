
using Zoo.BLL.DTOs.AnimalsCages;

namespace Zoo.BLL.Services.Interfaces;

public interface IAnimalCageService
{
    Task<IEnumerable<AnimalCageDto>> GetByAnimalIdAsync(int animalId, CancellationToken cancellationToken = default);
    Task<IEnumerable<AnimalCageDto>> GetByCageIdAsync(int cageId, CancellationToken cancellationToken = default);
    Task<bool> AddAsync(AnimalCageDto dto, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(AnimalCageDto dto, CancellationToken cancellationToken = default);
}
