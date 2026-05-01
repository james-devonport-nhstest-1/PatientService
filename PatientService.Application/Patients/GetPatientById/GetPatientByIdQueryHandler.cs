using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mediator;
using PatientService.Domain;

namespace PatientService.Application.Patients.GetPatientById;

public sealed class GetPatientByIdQueryHandler(IPatientRepository repository)
    : IQueryHandler<GetPatientByIdQuery, Patient>
{
    public ValueTask<Patient?> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken) =>
        repository.GetPatientById(query.PatientId, cancellationToken);

    // // My real-world implementation might look something like this, using an open-generic result and querying a data context
    // public ValueTask<Result<PatientModel>> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
    // {
    //     var patient = await dbContext.Set<Patient>()
    //         .Active()
    //         .FirstOrDefaultAsync(patient => patient.Id == query.PatientId);
    //
    //     if (patient is null)
    //     {
    //         return Result<PatientModel>.Failure(query.PatientId);
    //     }
    //
    //     return Result<PatientModel>.Success(patient);
    // }
}