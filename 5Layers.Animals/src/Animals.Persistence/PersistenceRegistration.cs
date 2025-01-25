using Animals.Persistence.Core.Animals.DataProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Animals.Persistence;

public static class PersistenceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IAnimalsDataProvider, AnimalsDataProvider>();
    }
}