
using Zoo.BLL.DTOs.Volunteers;

namespace Zoo.BLL.Services.Interfaces;

public interface IVolunteerService
{
    Task<IEnumerable<VolunteerReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<VolunteerReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<VolunteerReadDto> CreateAsync(VolunteerCreateDto dto, CancellationToken cancellationToken = default);
    Task<VolunteerReadDto> UpdateAsync(int id, VolunteerUpdateDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
