using Mapster;
using Zoo.BLL.DTOs.VolunteersDepartment;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class VolunteersDepartmentService : IVolunteersDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public VolunteersDepartmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<VolunteersDepartmentReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.VolunteerDepartments.GetAllAsync(cancellationToken);
        return entities.Adapt<IEnumerable<VolunteersDepartmentReadDto>>();
    }

    public async Task<VolunteersDepartmentReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.VolunteerDepartments.GetByIdAsync(id);
        return entity is null ? null : entity.Adapt<VolunteersDepartmentReadDto>();
    }

    public async Task<VolunteersDepartmentReadDto> CreateAsync(VolunteersDepartmentCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<VolunteerDepartment>();
        await _unitOfWork.VolunteerDepartments.AddAsync(entity);
        await _unitOfWork.SaveAsync(    );
        return entity.Adapt<VolunteersDepartmentReadDto>();
    }

    public async Task<VolunteersDepartmentReadDto> UpdateAsync(int id, VolunteersDepartmentUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.VolunteerDepartments.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Department with ID={id} not found");

        dto.Adapt(entity);
        await _unitOfWork.VolunteerDepartments.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return entity.Adapt<VolunteersDepartmentReadDto>();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.VolunteerDepartments.GetByIdAsync(id);
        if (entity == null) return false;

        await _unitOfWork.VolunteerDepartments.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
