using Mapster;
using Zoo.BLL.DTOs.Animals;
using Zoo.BLL.DTOs.AnimalsCages;
using Zoo.BLL.DTOs.AnimalTypes;
using Zoo.BLL.DTOs.Cages;
using Zoo.BLL.DTOs.Owners;
using Zoo.BLL.DTOs.Volunteers;
using Zoo.BLL.DTOs.VolunteersDepartment;
using Zoo.DAL.Entity;

namespace Zoo.BLL.Configuration
{
    public static class MapsterConfig
    {
        private static bool _isConfigured = false;

        public static void RegisterMappings()
        {
            if (_isConfigured)
                return;

            TypeAdapterConfig<Owner, OwnerReadDto>.NewConfig();
            TypeAdapterConfig<OwnerCreateDto, Owner>.NewConfig();
            TypeAdapterConfig<OwnerUpdateDto, Owner>.NewConfig();

            TypeAdapterConfig<AnimalType, AnimalTypeReadDto>.NewConfig();
            TypeAdapterConfig<AnimalTypeCreateDto, AnimalType>.NewConfig();
            TypeAdapterConfig<AnimalTypeUpdateDto, AnimalType>.NewConfig();

            TypeAdapterConfig<Cage, CageReadDto>.NewConfig()
                .Map(dest => dest.AnimalTypeName, src => src.AnimalType.AnimalTypeName);
            TypeAdapterConfig<CageCreateDto, Cage>.NewConfig();
            TypeAdapterConfig<CageUpdateDto, Cage>.NewConfig();

            TypeAdapterConfig<Animal, AnimalReadDto>.NewConfig()
                .Map(dest => dest.OwnerName, src => src.Owner.Name)
                .Map(dest => dest.AnimalTypeName, src => src.AnimalType.AnimalTypeName);
            TypeAdapterConfig<AnimalCreateDto, Animal>.NewConfig();
            TypeAdapterConfig<AnimalUpdateDto, Animal>.NewConfig();

            TypeAdapterConfig<AnimalCage, AnimalCageDto>.NewConfig();
            TypeAdapterConfig<AnimalCage, AnimalCage>.NewConfig();

            TypeAdapterConfig<Volunteer, VolunteerReadDto>.NewConfig()
                .Map(dest => dest.AnimalName, src => src.Animal.Name)
                .Map(dest => dest.DepartmentName, src => src.Department.DepartmentName);
            TypeAdapterConfig<VolunteerCreateDto, Volunteer>.NewConfig();
            TypeAdapterConfig<VolunteerUpdateDto, Volunteer>.NewConfig();

            TypeAdapterConfig<VolunteerDepartment, VolunteersDepartmentReadDto>.NewConfig();
            TypeAdapterConfig<VolunteersDepartmentCreateDto, VolunteerDepartment>.NewConfig();
            TypeAdapterConfig<VolunteersDepartmentUpdateDto, VolunteerDepartment>.NewConfig();

            TypeAdapterConfig.GlobalSettings.Compile();

            _isConfigured = true;
        }
    }
}
