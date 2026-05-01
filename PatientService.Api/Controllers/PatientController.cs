using Mediator;
using Microsoft.AspNetCore.Mvc;
using PatientService.Application.Patients.GetPatientById;

namespace PatientService.Api.Controllers;

[Route("api/patient")]
public class PatientController(IMediator mediator) : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id < 0)
        {
            return BadRequest();
        }
        
        var query = new GetPatientByIdQuery(id);
        var result = await mediator.Send(query);
        
        return result is not null ?
            Ok(result) :
            NotFound(id);
    }
}