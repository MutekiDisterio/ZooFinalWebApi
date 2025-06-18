using Mapster;
using Zoo.BLL.DTOs.Owners;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class OwnerService : IOwnerService
{
    private readonly IUnitOfWork _unitOfWork;

    public OwnerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OwnerReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var owners = await _unitOfWork.Owners.GetAllAsync(cancellationToken);
        return owners.Adapt<IEnumerable<OwnerReadDto>>();
    }

    public async Task<OwnerReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var owner = await _unitOfWork.Owners.GetByIdAsync(id);
        return owner is null ? null : owner.Adapt<OwnerReadDto>();
    }

    public async Task<OwnerReadDto> CreateAsync(OwnerCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<Owner>();
        await _unitOfWork.Owners.AddAsync(entity);
        await _unitOfWork.SaveAsync(    );
        return entity.Adapt<OwnerReadDto>();
    }

    public async Task<OwnerReadDto> UpdateAsync(int id, OwnerUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Owners.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Owner with ID={id} not found");

        dto.Adapt(entity);
        await _unitOfWork.Owners.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return entity.Adapt<OwnerReadDto>();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Owners.GetByIdAsync(id);
        if (entity == null) return false;

        await _unitOfWork.Owners.DeleteAsync(entity     );
        await _unitOfWork.SaveAsync();
        return true;
    }
}
