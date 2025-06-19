using Mapster;
using Zoo.BLL.DTOs.Cages;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;
using Zoo.BLL.Exceptions; 

namespace Zoo.BLL.Services
{
    public class CageService : ICageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CageReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var cages = await _unitOfWork.Cages.GetAllAsync(cancellationToken);
            return cages.Adapt<IEnumerable<CageReadDto>>();
        }

        public async Task<CageReadDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var cage = await _unitOfWork.Cages.GetByIdAsync(id);
            if (cage == null)
                throw new NotFoundException($"Cage with ID={id} not found.");

            return cage.Adapt<CageReadDto>();
        }

        public async Task<CageReadDto> CreateAsync(CageCreateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = dto.Adapt<Cage>();
            await _unitOfWork.Cages.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Adapt<CageReadDto>();
        }

        public async Task<CageReadDto> UpdateAsync(int id, CageUpdateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Cages.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"Cage with ID={id} not found.");

            dto.Adapt(entity);
            await _unitOfWork.Cages.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Adapt<CageReadDto>();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.Cages.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"Cage with ID={id} not found.");

            await _unitOfWork.Cages.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
