using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PatientService.Application.Patients;
using PatientService.Domain;

namespace PatientService.Infrastructure;

public sealed class InMemoryPatientRepository : IPatientRepository
{
    private readonly object _lock = new { };
    private readonly List<Patient> _db = PreLoadedPatientList;

    public ValueTask<Patient?> GetPatientById(int id, CancellationToken cancellationToken)
    {
        lock (_lock)
        {
            var patient = _db.FirstOrDefault(patient => patient.Id == id);
            
            return new ValueTask<Patient?>(patient);
        }
    }

    // Pre-seed the database in memory
    private static List<Patient> PreLoadedPatientList =>
    [
        new()
        {
            Id = 1,
            Name = "Lando Norris",
            DateOfBirth = new DateTime(1980, 1, 1),
            GPPractice = "McLaren Medical",
            NHSNumber = "11111",
        },
        new()
        {
            Id = 2,
            Name = "Carlos Sainz",
            DateOfBirth = new DateTime(1980, 2, 2),
            GPPractice = "Ferrari & Co",
            NHSNumber = "22222",
        },
        new()
        {
            Id = 3,
            Name = "Lewis Hamilton",
            DateOfBirth = new DateTime(1980, 3, 3),
            GPPractice = "Mercedes Medical",
            NHSNumber = "33333",
        },
        new()
        {
            Id = 4,
            Name = "Oscar Piastri",
            DateOfBirth = new DateTime(1980, 4, 4),
            GPPractice = "McLaren Medical",
            NHSNumber = "44444",
        },
        new()
        {
            Id = 5,
            Name = "Max Verstappen",
            DateOfBirth = new DateTime(1980, 5, 5),
            GPPractice = "Red Bull Surgery",
            NHSNumber = "55555",
        }
    ];
}
