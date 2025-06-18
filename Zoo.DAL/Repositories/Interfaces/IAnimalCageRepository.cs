using Zoo.DAL.Entity;
using Zoo.DAL.Repositories.Interfaces;

public interface IAnimalCageRepository : IEFGenericRepository<AnimalCage>
{
    Task<AnimalCage> FindAsync(Func<object, bool> value);
    void Update(AnimalCage entity);
}