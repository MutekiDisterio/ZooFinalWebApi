using AutoMapper;
using Zoo.BLL.DTOs.Volunteers;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class VolunteerService : IVolunteerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VolunteerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VolunteerReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var volunteers = await _unitOfWork.Volunteers.GetAllAsync();
        return _mapper.Map<IEnumerable<VolunteerReadDto>>(volunteers);
    }

    public async Task<VolunteerReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Volunteers.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<VolunteerReadDto>(entity);
    }

    public async Task<VolunteerReadDto> CreateAsync(VolunteerCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Volunteer>(dto);
        await _unitOfWork.Volunteers.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<VolunteerReadDto>(entity);
    }

    public async Task<VolunteerReadDto> UpdateAsync(int id, VolunteerUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Volunteers.GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Volunteer with ID={id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Volunteers.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<VolunteerReadDto>(entity);
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
