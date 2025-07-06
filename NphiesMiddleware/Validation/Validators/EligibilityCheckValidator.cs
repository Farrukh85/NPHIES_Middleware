using FluentValidation;
using NphiesMiddleware.Core.DTOs;

namespace NphiesMiddleware.Validation.Validators;

public class EligibilityCheckValidator : AbstractValidator<EligibilityCheck>
{
    public EligibilityCheckValidator()
    {
        RuleFor(x => x.PatientId).NotEmpty();
        RuleFor(x => x.CoverageId).NotEmpty();
    }
}
