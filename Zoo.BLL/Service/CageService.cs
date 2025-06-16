using AutoMapper;
using Zoo.BLL.DTOs.Cages;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.BLL.Services;

public class CageService : ICageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CageReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cages = await _unitOfWork.Cages.GetAllAsync();
        return _mapper.Map<IEnumerable<CageReadDto>>(cages);
    }

    public async Task<CageReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var cage = await _unitOfWork.Cages.GetByIdAsync(id);
        return cage is null ? null : _mapper.Map<CageReadDto>(cage);
    }

    public async Task<CageReadDto> CreateAsync(CageCreateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Cage>(dto);
        await _unitOfWork.Cages.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<CageReadDto>(entity);
    }

    Task<IEnumerable<CageReadDto>> ICageService.GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<CageReadDto?> ICageService.GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<CageReadDto> ICageService.CreateAsync(CageCreateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<CageReadDto> ICageService.UpdateAsync(int id, CageUpdateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<bool> ICageService.DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    // Removed incomplete method causing errors
}
