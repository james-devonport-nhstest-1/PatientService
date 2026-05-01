using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PatientService.Domain;

namespace PatientService.Application.Patients;

public interface IPatientRepository
{
    ValueTask<Patient?> GetPatientById(int id, CancellationToken cancellationToken);
}
