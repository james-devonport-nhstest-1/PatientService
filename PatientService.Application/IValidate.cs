using System.Diagnostics.CodeAnalysis;
using Mediator;

namespace PatientService.Application;

public interface IValidate : IMessage
{
    bool IsValid([NotNullWhen(false)] out ValidationError? error);
}
