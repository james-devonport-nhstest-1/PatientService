using System.Threading;
using System.Threading.Tasks;
using Mediator;

namespace PatientService.Application.Pipeline;

public sealed class MessageValidatorBehaviour<TMessage, TResponse> : MessagePreProcessor<TMessage, TResponse>
    where TMessage : IValidate
{
    protected override ValueTask Handle(TMessage message, CancellationToken cancellationToken)
    {
        if (!message.IsValid(out var validationError))
        {
            throw new ValidationException(validationError);
        }

        return default;
    }
}
