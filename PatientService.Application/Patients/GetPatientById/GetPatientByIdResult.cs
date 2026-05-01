using System;

namespace PatientService.Application.Patients.GetPatientById;

public record GetPatientByIdResult
{
    public string NHSNumber { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string GPPractice { get; set; }
}