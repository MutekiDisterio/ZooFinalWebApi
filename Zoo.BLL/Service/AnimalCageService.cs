using AutoMapper;
using Zoo.BLL.DTOs.AnimalsCages;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class AnimalCageService : IAnimalCageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnimalCageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnimalCageDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.AnimalCages.GetAllAsync();
        return _mapper.Map<IEnumerable<AnimalCageDto>>(entities);
    }

    public async Task<AnimalCageDto> CreateAsync(AnimalCageDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<AnimalCage>(dto);
        await _unitOfWork.AnimalCages.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<AnimalCageDto>(entity);
    }

    public async Task<bool> DeleteAsync(int animalId, int cageId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AnimalCages
            .FindAsync(ac => ((AnimalCage)ac).AnimalId == animalId && ((AnimalCage)ac).CageId == cageId);

        if (entity == null) return false;

        await _unitOfWork.AnimalCages.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public Task<IEnumerable<AnimalCageDto>> GetByAnimalIdAsync(int animalId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnimalCageDto>> GetByCageIdAsync(int cageId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddAsync(AnimalCageDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(AnimalCageDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
