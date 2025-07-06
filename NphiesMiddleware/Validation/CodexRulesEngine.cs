namespace NphiesMiddleware.Validation;

public class CodexRulesEngine
{
    public Task<bool> EvaluateAsync<T>(T payload)
    {
        // TODO: Integrate Codex Rules Engine
        return Task.FromResult(true);
    }
}
