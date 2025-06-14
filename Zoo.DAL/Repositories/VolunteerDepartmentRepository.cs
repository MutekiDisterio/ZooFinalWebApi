using Zoo.DAL.Data;
using Zoo.DAL.Entity;
using Zoo.DAL.Repositories;

public class VolunteerDepartmentRepository : GenericRepository<VolunteerDepartment>, IVolunteerDepartmentRepository
{
    public VolunteerDepartmentRepository(ZooManagementContext context) : base(context) { }
}
