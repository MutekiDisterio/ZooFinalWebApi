using AutoMapper;
using Zoo.BLL.DTOs.VolunteersDepartment;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class VolunteersDepartmentService : IVolunteersDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VolunteersDepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VolunteersDepartmentReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.VolunteerDepartments.GetAllAsync();
        return _mapper.Map<IEnumerable<VolunteersDepartmentReadDto>>(entities);
    }

    public async Task<VolunteersDepartmentReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.VolunteerDepartments.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<VolunteersDepartmentReadDto>(entity);
    }

    public async Task<VolunteersDepartmentReadDto> CreateAsync(VolunteersDepartmentCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<VolunteerDepartment>(dto);
        await _unitOfWork.VolunteerDepartments.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<VolunteersDepartmentReadDto>(entity);
    }

    public async Task<VolunteersDepartmentReadDto> UpdateAsync(int id, VolunteersDepartmentUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.VolunteerDepartments.GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Department with ID={id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.VolunteerDepartments.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<VolunteersDepartmentReadDto>(entity);
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
