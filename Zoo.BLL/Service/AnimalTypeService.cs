using AutoMapper;
using Zoo.BLL.DTOs.AnimalTypes;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class AnimalTypeService : IAnimalTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnimalTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnimalTypeReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.AnimalTypes.GetAllAsync();
        return _mapper.Map<IEnumerable<AnimalTypeReadDto>>(entities);
    }

    public async Task<AnimalTypeReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AnimalTypes.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<AnimalTypeReadDto>(entity);
    }

    public async Task<AnimalTypeReadDto> CreateAsync(AnimalTypeCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<AnimalType>(dto);
        await _unitOfWork.AnimalTypes.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<AnimalTypeReadDto>(entity);
    }

    public async Task<AnimalTypeReadDto> UpdateAsync(int id, AnimalTypeUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AnimalTypes.GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"AnimalType with ID={id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.AnimalTypes.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<AnimalTypeReadDto>(entity);
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
