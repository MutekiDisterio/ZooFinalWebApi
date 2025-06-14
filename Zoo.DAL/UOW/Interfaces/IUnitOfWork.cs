using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.UOW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOwnerRepository Owners { get; }
        IAnimalTypeRepository AnimalTypes { get; }
        ICageRepository Cages { get; }
        IAnimalRepository Animals { get; }
        IAnimalCageRepository AnimalCages { get; }
        IVolunteerRepository Volunteers { get; }
        IVolunteerDepartmentRepository VolunteerDepartments { get; }

        Task<int> SaveAsync();
    }

}
