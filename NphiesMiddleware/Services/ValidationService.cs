using FluentValidation;
using NphiesMiddleware.Core.Interfaces;

namespace NphiesMiddleware.Services;

public class ValidationService : IValidationService
{
    private readonly IServiceProvider _provider;

    public ValidationService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task ValidateAsync<T>(T dto)
    {
        var validator = _provider.GetService<IValidator<T>>();
        if (validator != null)
        {
            await validator.ValidateAndThrowAsync(dto);
        }
    }
}
