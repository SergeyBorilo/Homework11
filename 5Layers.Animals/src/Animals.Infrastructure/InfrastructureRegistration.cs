using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Animals.Core.Domain.Common;
using Animals.Infrastructure.Core.Domain.Animals.Common;

namespace Animals.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IAnimalsRepository, AnimalsRepository>();
    }
}