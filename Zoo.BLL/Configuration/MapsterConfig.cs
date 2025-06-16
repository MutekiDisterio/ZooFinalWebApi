using Mapster;
using Zoo.BLL.DTOs.Animals;
using Zoo.BLL.DTOs.AnimalsCages;
using Zoo.BLL.DTOs.AnimalTypes;
using Zoo.BLL.DTOs.Cages;
using Zoo.BLL.DTOs.Owners;
using Zoo.BLL.DTOs.Volunteers;
using Zoo.BLL.DTOs.VolunteersDepartment;
using Zoo.DAL.Entity;

namespace Zoo.BLL.Configuration;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        // Owner
        TypeAdapterConfig<Owner, OwnerReadDto>.NewConfig();
        TypeAdapterConfig<OwnerCreateDto, Owner>.NewConfig();
        TypeAdapterConfig<OwnerUpdateDto, Owner>.NewConfig();

        // AnimalType
        TypeAdapterConfig<AnimalType, AnimalTypeReadDto>.NewConfig();
        TypeAdapterConfig<AnimalTypeCreateDto, AnimalType>.NewConfig();
        TypeAdapterConfig<AnimalTypeUpdateDto, AnimalType>.NewConfig();

        // Cage
        TypeAdapterConfig<Cage, CageReadDto>.NewConfig()
            .Map(dest => dest.AnimalTypeName, src => src.AnimalType.AnimalTypeName); 
        TypeAdapterConfig<CageCreateDto, Cage>.NewConfig();
        TypeAdapterConfig<CageUpdateDto, Cage>.NewConfig();

        // Animal
        TypeAdapterConfig<Animal, AnimalReadDto>.NewConfig()
            .Map(dest => dest.OwnerName, src => src.Owner.Name)
            .Map(dest => dest.AnimalTypeName, src => src.AnimalType.AnimalTypeName);
        TypeAdapterConfig<AnimalCreateDto, Animal>.NewConfig();
        TypeAdapterConfig<AnimalUpdateDto, Animal>.NewConfig();

        // AnimalCage
        TypeAdapterConfig<AnimalCage, AnimalCageDto>.NewConfig();
        TypeAdapterConfig<AnimalCage, AnimalCage>.NewConfig();

        // Volunteer
        TypeAdapterConfig<Volunteer, VolunteerReadDto>.NewConfig()
            .Map(dest => dest.AnimalName, src => src.Animal.Name)
            .Map(dest => dest.DepartmentName, src => src.Department.DepartmentName);
        TypeAdapterConfig<VolunteerCreateDto, Volunteer>.NewConfig();
        TypeAdapterConfig<VolunteerUpdateDto, Volunteer>.NewConfig();

        // VolunteersDepartment
        TypeAdapterConfig<VolunteerDepartment, VolunteersDepartmentReadDto>.NewConfig();
        TypeAdapterConfig<VolunteersDepartmentCreateDto, VolunteerDepartment>.NewConfig();
        TypeAdapterConfig<VolunteersDepartmentUpdateDto, VolunteerDepartment>.NewConfig();
    }
}
