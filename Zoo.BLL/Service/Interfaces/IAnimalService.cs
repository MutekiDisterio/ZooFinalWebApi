
using Zoo.BLL.DTOs;
using Zoo.BLL.DTOs.Animals;
using Zoo.BLL.DTOs.Owners;
using Zoo.DAL.Entity.HelpModels;

namespace Zoo.BLL.Services.Interfaces;

public interface IAnimalService
{
    Task<PagedResult<AnimalReadDto>> GetPagedAsync(AnimalQueryParameters parameters, CancellationToken cancellationToken = default);
    Task<IEnumerable<AnimalReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AnimalReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<AnimalReadDto> CreateAsync(AnimalCreateDto dto, CancellationToken cancellationToken = default);
    Task<AnimalReadDto> UpdateAsync(int id, AnimalUpdateDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
