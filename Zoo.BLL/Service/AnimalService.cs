using AutoMapper;
using Zoo.BLL.DTOs.Animals;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class AnimalService : IAnimalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnimalService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnimalReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.Animals.GetAllAsync();
        return _mapper.Map<IEnumerable<AnimalReadDto>>(entities);
    }

    public async Task<AnimalReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Animals.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<AnimalReadDto>(entity);
    }

    public async Task<AnimalReadDto> CreateAsync(AnimalCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Animal>(dto);
        await _unitOfWork.Animals.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<AnimalReadDto>(entity);
    }

    public async Task<AnimalReadDto> UpdateAsync(int id, AnimalUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Animals.GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Animal with ID={id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Animals.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<AnimalReadDto>(entity);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Animals.GetByIdAsync(id);
        if (entity == null) return false;

        await _unitOfWork.Animals.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
