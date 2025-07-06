# NphiesMiddleware

A .NET Core 8 Web API skeleton that demonstrates a clean architecture approach for integrating with the NPHIES platform.

## Structure

- **Api** — Controllers exposing HTTP endpoints.
- **Core** — Domain models, DTOs and service interfaces.
- **Services** — Implementation of business services.
- **Validation** — FluentValidation validators and Codex rules engine integration.
- **Transformers** — Helpers for converting DTOs to FHIR resources.
- **Integration** — HttpClient policies and OAuth2 helpers.
- **Persistence** — EF Core DbContext and repositories.
- **Logging** — Serilog configuration.
- **Tests** — xUnit test project.

## Running

This project targets `.NET 8`. Install the [.NET 8 SDK](https://dotnet.microsoft.com/) and run:

```bash
cd NphiesMiddleware
 dotnet restore
 dotnet run
```

Then navigate to `https://localhost:5001/swagger` to view Swagger UI.
