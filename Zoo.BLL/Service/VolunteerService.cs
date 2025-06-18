using Mapster;
using Zoo.BLL.DTOs.Volunteers;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class VolunteerService : IVolunteerService
{
    private readonly IUnitOfWork _unitOfWork;

    public VolunteerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<VolunteerReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var volunteers = await _unitOfWork.Volunteers.GetAllAsync(cancellationToken);
        return volunteers.Adapt<IEnumerable<VolunteerReadDto>>();
    }

    public async Task<VolunteerReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Volunteers.GetByIdAsync(id);
        return entity is null ? null : entity.Adapt<VolunteerReadDto>();
    }

    public async Task<VolunteerReadDto> CreateAsync(VolunteerCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<Volunteer>();
        await _unitOfWork.Volunteers.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return entity.Adapt<VolunteerReadDto>();
    }

    public async Task<VolunteerReadDto> UpdateAsync(int id, VolunteerUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Volunteers.GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Volunteer with ID={id} not found");

        dto.Adapt(entity);
        await _unitOfWork.Volunteers.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return entity.Adapt<VolunteerReadDto>();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Volunteers.GetByIdAsync(id);
        if (entity == null) return false;

        await _unitOfWork.Volunteers.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
