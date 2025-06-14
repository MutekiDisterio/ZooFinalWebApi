using Microsoft.EntityFrameworkCore;
using Zoo.DAL.Data;
using Zoo.DAL.Entity;
using Zoo.DAL.Repositories;

public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
{
    public AnimalRepository(ZooManagementContext context) : base(context) { }

    public async Task<IEnumerable<Animal>> GetAnimalsWithTypeAndOwnerAsync()
    {
        return await _context.Animals
            .Include(a => a.AnimalType)
            .Include(a => a.Owner)
            .ToListAsync();
    }
}
