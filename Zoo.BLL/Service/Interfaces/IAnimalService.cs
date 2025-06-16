
using Zoo.BLL.DTOs.Animals;

namespace Zoo.BLL.Services.Interfaces;

public interface IAnimalService
{
    Task<IEnumerable<AnimalReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AnimalReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<AnimalReadDto> CreateAsync(AnimalCreateDto dto, CancellationToken cancellationToken = default);
    Task<AnimalReadDto> UpdateAsync(int id, AnimalUpdateDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
