using Microsoft.Extensions.DependencyInjection;
using PatientService.Application.Patients;

namespace PatientService.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services.AddSingleton<IPatientRepository, InMemoryPatientRepository>();
    }
}
