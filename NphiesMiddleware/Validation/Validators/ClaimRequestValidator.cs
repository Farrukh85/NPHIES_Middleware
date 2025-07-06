using FluentValidation;
using NphiesMiddleware.Core.DTOs;

namespace NphiesMiddleware.Validation.Validators;

public class ClaimRequestValidator : AbstractValidator<ClaimRequest>
{
    public ClaimRequestValidator()
    {
        RuleFor(x => x.ClaimId).NotEmpty();
        RuleFor(x => x.PatientId).NotEmpty();
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}
