using Zoo.BLL.DTOs.AnimalsCages;

namespace Zoo.BLL.Services.Interfaces;

public interface IAnimalCageService
{
    Task<IEnumerable<AnimalCageDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AnimalCageDto?> GetByIdAsync(int animalId, int cageId, CancellationToken cancellationToken = default);
    Task<AnimalCageDto> CreateAsync(AnimalCageDto dto, CancellationToken cancellationToken = default);
    Task<AnimalCageDto?> UpdateAsync(int animalId, int cageId, AnimalCageDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int animalId, int cageId, CancellationToken cancellationToken = default);

    Task<bool> AddAsync(AnimalCageDto dto, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(AnimalCageDto dto, CancellationToken cancellationToken = default);

    Task<IEnumerable<AnimalCageDto>> GetByAnimalIdAsync(int animalId, CancellationToken cancellationToken = default);
    Task<IEnumerable<AnimalCageDto>> GetByCageIdAsync(int cageId, CancellationToken cancellationToken = default);
}
