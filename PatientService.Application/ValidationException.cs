using System;

namespace PatientService.Application;

public sealed class ValidationException : Exception
{
    public ValidationException(ValidationError validationError)
        : base("Validation error") => ValidationError = validationError;

    public ValidationError ValidationError { get; }
}
