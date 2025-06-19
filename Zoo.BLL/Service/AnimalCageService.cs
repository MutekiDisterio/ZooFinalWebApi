using Mapster;
using Zoo.BLL.DTOs.AnimalsCages;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity;
using Zoo.DAL.UOW.Interfaces;
using Microsoft.EntityFrameworkCore;
using Zoo.BLL.Exceptions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Zoo.BLL.Services
{
    public class AnimalCageService : IAnimalCageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalCageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AnimalCageDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _unitOfWork.AnimalCages.GetAllAsync(cancellationToken);
            return entities.Adapt<IEnumerable<AnimalCageDto>>();
        }

        public async Task<AnimalCageDto> GetByIdAsync(int animalId, int cageId, CancellationToken cancellationToken = default)
        {
            var query = await _unitOfWork.AnimalCages.FindByCondotion(ac =>
                ac.AnimalId == animalId && ac.CageId == cageId);

            var entity = await query.FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException($"AnimalCage with AnimalId={animalId} and CageId={cageId} not found.");

            return entity.Adapt<AnimalCageDto>();
        }

        public async Task<AnimalCageDto> CreateAsync(AnimalCageDto dto, CancellationToken cancellationToken = default)
        {
            var entity = dto.Adapt<AnimalCage>();
            await _unitOfWork.AnimalCages.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Adapt<AnimalCageDto>();
        }

        public async Task<AnimalCageDto> UpdateAsync(int animalId, int cageId, AnimalCageDto dto, CancellationToken cancellationToken = default)
        {
            var query = await _unitOfWork.AnimalCages.FindByCondotion(ac =>
                ac.AnimalId == animalId && ac.CageId == cageId);

            var entity = await query.FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException($"AnimalCage with AnimalId={animalId} and CageId={cageId} not found.");

            dto.Adapt(entity);
            _unitOfWork.AnimalCages.Update(entity);
            await _unitOfWork.SaveAsync();
            return entity.Adapt<AnimalCageDto>();
        }

        public async Task<bool> DeleteAsync(int animalId, int cageId, CancellationToken cancellationToken = default)
        {
            var query = await _unitOfWork.AnimalCages.FindByCondotion(ac =>
                ac.AnimalId == animalId && ac.CageId == cageId);

            var entity = await query.FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException($"AnimalCage with AnimalId={animalId} and CageId={cageId} not found.");

            await _unitOfWork.AnimalCages.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<AnimalCageDto>> GetByAnimalIdAsync(int animalId, CancellationToken cancellationToken = default)
        {
            var query = await _unitOfWork.AnimalCages.FindByCondotion(ac => ac.AnimalId == animalId);
            var list = await query.ToListAsync(cancellationToken);
            return list.Adapt<IEnumerable<AnimalCageDto>>();
        }

        public async Task<IEnumerable<AnimalCageDto>> GetByCageIdAsync(int cageId, CancellationToken cancellationToken = default)
        {
            var query = await _unitOfWork.AnimalCages.FindByCondotion(ac => ac.CageId == cageId);
            var list = await query.ToListAsync(cancellationToken);
            return list.Adapt<IEnumerable<AnimalCageDto>>();
        }

        public async Task<bool> AddAsync(AnimalCageDto dto, CancellationToken cancellationToken = default)
        {
            var query = await _unitOfWork.AnimalCages.FindByCondotion(ac =>
                ac.AnimalId == dto.AnimalId && ac.CageId == dto.CageId);

            if (await query.AnyAsync(cancellationToken))
                throw new ConflictException($"AnimalCage with AnimalId={dto.AnimalId} and CageId={dto.CageId} already exists.");

            var entity = dto.Adapt<AnimalCage>();
            await _unitOfWork.AnimalCages.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(AnimalCageDto dto, CancellationToken cancellationToken = default)
        {
            var query = await _unitOfWork.AnimalCages.FindByCondotion(ac =>
                ac.AnimalId == dto.AnimalId && ac.CageId == dto.CageId);

            var entity = await query.FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException($"AnimalCage with AnimalId={dto.AnimalId} and CageId={dto.CageId} not found.");

            await _unitOfWork.AnimalCages.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
