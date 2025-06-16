using Zoo.BLL.DTOs.VolunteersDepartment;

namespace Zoo.BLL.Services.Interfaces;

public interface IVolunteersDepartmentService
{
    Task<IEnumerable<VolunteersDepartmentReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<VolunteersDepartmentReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<VolunteersDepartmentReadDto> CreateAsync(VolunteersDepartmentCreateDto dto, CancellationToken cancellationToken = default);
    Task<VolunteersDepartmentReadDto> UpdateAsync(int id, VolunteersDepartmentUpdateDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
