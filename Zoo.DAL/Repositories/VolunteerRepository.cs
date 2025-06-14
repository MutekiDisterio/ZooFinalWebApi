using Microsoft.EntityFrameworkCore;
using Zoo.DAL.Data;
using Zoo.DAL.Entity;
using Zoo.DAL.Repositories;

public class VolunteerRepository : GenericRepository<Volunteer>, IVolunteerRepository
{
    public VolunteerRepository(ZooManagementContext context) : base(context) { }

    public async Task<IEnumerable<Volunteer>> GetVolunteersWithAnimalsAsync()
    {
        return await _context.Volunteers
            .Include(v => v.Animal)
            .Include(v => v.Department)
            .ToListAsync();
    }
}
