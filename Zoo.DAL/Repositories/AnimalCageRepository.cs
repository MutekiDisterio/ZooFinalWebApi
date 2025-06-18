using Zoo.DAL.Data;
using Zoo.DAL.Entity;
using Zoo.DAL.Repositories;

public class AnimalCageRepository : GenericRepository<AnimalCage>, IAnimalCageRepository
{
    public AnimalCageRepository(ZooManagementContext context) : base(context) { }

    public Task<AnimalCage> FindAsync(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}