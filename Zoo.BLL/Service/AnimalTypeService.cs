using Mapster;
using Zoo.BLL.DTOs.AnimalTypes;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class AnimalTypeService : IAnimalTypeService
{
    private readonly IUnitOfWork _unitOfWork;

    public AnimalTypeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AnimalTypeReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.AnimalTypes.GetAllAsync(cancellationToken);
        return entities.Adapt<IEnumerable<AnimalTypeReadDto>>();
    }

    public async Task<AnimalTypeReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AnimalTypes.GetByIdAsync(id);
        return entity?.Adapt<AnimalTypeReadDto>();
    }

    public async Task<AnimalTypeReadDto> CreateAsync(AnimalTypeCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<AnimalType>();
        await _unitOfWork.AnimalTypes.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return entity.Adapt<AnimalTypeReadDto>();
    }

    public async Task<AnimalTypeReadDto> UpdateAsync(int id, AnimalTypeUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AnimalTypes.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"AnimalType with ID={id} not found");

        dto.Adapt(entity); 
        await _unitOfWork.AnimalTypes.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return entity.Adapt<AnimalTypeReadDto>();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AnimalTypes.GetByIdAsync(id);
        if (entity == null) return false;

        await _unitOfWork.AnimalTypes.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
