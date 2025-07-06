using FluentValidation;
using NphiesMiddleware.Core.DTOs;

namespace NphiesMiddleware.Validation.Validators;

public class PreAuthorizationValidator : AbstractValidator<PreAuthorization>
{
    public PreAuthorizationValidator()
    {
        RuleFor(x => x.AuthorizationId).NotEmpty();
        RuleFor(x => x.PatientId).NotEmpty();
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}
