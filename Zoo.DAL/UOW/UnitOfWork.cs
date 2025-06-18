using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.DAL.Data;
using Zoo.DAL.UOW.Interfaces;

namespace Zoo.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZooManagementContext _context;

        public IOwnerRepository Owners { get; }
        public IAnimalTypeRepository AnimalTypes { get; }
        public ICageRepository Cages { get; }
        public IAnimalRepository Animals { get; }
        public IAnimalCageRepository AnimalCages { get; }
        public IVolunteerRepository Volunteers { get; }
        public IVolunteerDepartmentRepository VolunteerDepartments { get; }

        public UnitOfWork(ZooManagementContext context)
        {
            _context = context;
            Owners = new OwnerRepository(context);
            AnimalTypes = new AnimalTypeRepository(context);
            Cages = new CageRepository(context);
            Animals = new AnimalRepository(context);
            AnimalCages = new AnimalCageRepository(context);
            Volunteers = new VolunteerRepository(context);
            VolunteerDepartments = new VolunteerDepartmentRepository(context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }

}