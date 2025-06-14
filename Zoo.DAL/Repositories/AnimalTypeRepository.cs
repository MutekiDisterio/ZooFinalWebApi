using Zoo.DAL.Data;
using Zoo.DAL.Entity;
using Zoo.DAL.Repositories;

public class AnimalTypeRepository : GenericRepository<AnimalType>, IAnimalTypeRepository
{
    public AnimalTypeRepository(ZooManagementContext context) : base(context) { }
}
