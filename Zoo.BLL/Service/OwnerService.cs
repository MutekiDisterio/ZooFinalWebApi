using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoo.BLL.DTOs.Owners;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class OwnerService : IOwnerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OwnerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OwnerReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var owners = await _unitOfWork.Owners.GetAllAsync();
        return _mapper.Map<IEnumerable<OwnerReadDto>>(owners);
    }

    public async Task<OwnerReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var owner = await _unitOfWork.Owners.GetByIdAsync(id);
        return owner is null ? null : _mapper.Map<OwnerReadDto>(owner);
    }

    public async Task<OwnerReadDto> CreateAsync(OwnerCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Owner>(dto);
        await _unitOfWork.Owners.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<OwnerReadDto>(entity);
    }

    public async Task<OwnerReadDto> UpdateAsync(int id, OwnerUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Owners.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Owner with ID={id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Owners.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<OwnerReadDto>(entity);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Owners.GetByIdAsync(id);
        if (entity == null) return false;

        await _unitOfWork.Owners.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
