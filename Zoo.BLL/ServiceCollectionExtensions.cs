using Microsoft.Extensions.DependencyInjection;
using Zoo.BLL.Services;
using Zoo.BLL.Services.Interfaces;

namespace Zoo.BLL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IOwnerService, OwnerService>();
        services.AddScoped<IAnimalService, AnimalService>();
        services.AddScoped<IAnimalTypeService, AnimalTypeService>();
        services.AddScoped<ICageService, CageService>();
        services.AddScoped<IAnimalCageService, AnimalCageService>();
        services.AddScoped<IVolunteerService, VolunteerService>();
        services.AddScoped<IVolunteersDepartmentService, VolunteersDepartmentService>();

        return services;
    }
}
