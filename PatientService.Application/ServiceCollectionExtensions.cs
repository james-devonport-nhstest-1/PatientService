using Mediator;
using Microsoft.Extensions.DependencyInjection;
using PatientService.Application.Patients.GetPatientById;
using PatientService.Application.Pipeline;

namespace PatientService.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(options =>
            {
                options.Assemblies = [typeof(GetPatientByIdQuery)];
                options.ServiceLifetime = ServiceLifetime.Scoped;
            }
        );
        return services
            .AddSingleton(typeof(IPipelineBehavior<,>), typeof(ErrorLoggingBehaviour<,>))
            .AddSingleton(typeof(IPipelineBehavior<,>), typeof(MessageValidatorBehaviour<,>));
    }
}
