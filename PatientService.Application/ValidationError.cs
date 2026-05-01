using System.Collections.Generic;

namespace PatientService.Application;

public sealed record ValidationError(IEnumerable<string> Errors);
