using Zoo.DAL.Data;
using Zoo.DAL.Entity;
using Zoo.DAL.Repositories;

public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(ZooManagementContext context) : base(context) { }
}
