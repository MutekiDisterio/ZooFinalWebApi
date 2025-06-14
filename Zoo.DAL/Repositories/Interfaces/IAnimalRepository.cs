using Zoo.DAL.Entity;
using Zoo.DAL.Repositories.Interfaces;

public interface IAnimalRepository : IEFGenericRepository<Animal>
{
    Task<IEnumerable<Animal>> GetAnimalsWithTypeAndOwnerAsync();
}
