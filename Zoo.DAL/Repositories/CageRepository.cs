using Zoo.DAL.Data;
using Zoo.DAL.Entity;
using Zoo.DAL.Repositories;

public class CageRepository : GenericRepository<Cage>, ICageRepository
{
    public CageRepository(ZooManagementContext context) : base(context) { }
}
