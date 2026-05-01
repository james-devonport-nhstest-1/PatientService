using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mediator;
using PatientService.Domain;

namespace PatientService.Application.Patients.GetPatientById;

public record GetPatientByIdQuery(int PatientId) : IQuery<Patient>;
