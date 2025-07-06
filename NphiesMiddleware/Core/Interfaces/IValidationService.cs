using NphiesMiddleware.Core.DTOs;
using System.Threading.Tasks;

namespace NphiesMiddleware.Core.Interfaces;

public interface IValidationService
{
    Task ValidateAsync<T>(T dto);
}
