using System.Diagnostics.CodeAnalysis;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using PatientService.Application.Patients;
using PatientService.Application.Patients.GetPatientById;
using PatientService.Infrastructure;

namespace PatientService.Application.Tests.Patients;

[TestFixture, ExcludeFromCodeCoverage]
public class GetPatientByIdTests
{
    private IMediator _mediator;

    [SetUp]
    public void Setup()
    {
        var mockPatientRepository = new Mock<IPatientRepository>();

        // Mock the mediator pipeline
        var services = new ServiceCollection();
        
        services.AddScoped<IPatientRepository, InMemoryPatientRepository>();
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
            options.Assemblies = [ typeof(GetPatientByIdQuery).Assembly ];
        });
        
        var serviceProvider = services.BuildServiceProvider();
    
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }
    
    [Test]
    public async Task Should_GetSingleAction_When_RequestIsValid()
    {
        // Arrange
        var query = new GetPatientByIdQuery(1);
        
        // Act
        var result = await _mediator.Send(query);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo("Lando Norris"));
        Assert.That(result.NHSNumber, Is.EqualTo("11111"));
    }
    
    [Test]
    public async Task Should_ReturnError_When_IdDoesNotExist()
    {
        // Arrange
        var query = new GetPatientByIdQuery(int.MaxValue);
        
        // Act
        var result = await _mediator.Send(query);

        // Assert
        Assert.That(result, Is.Null);
    }
}