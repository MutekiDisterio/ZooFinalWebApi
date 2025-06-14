using Zoo.DAL.Entity;
using Zoo.DAL.Repositories.Interfaces;

public interface IVolunteerRepository : IEFGenericRepository<Volunteer>
{
    Task<IEnumerable<Volunteer>> GetVolunteersWithAnimalsAsync();
}
