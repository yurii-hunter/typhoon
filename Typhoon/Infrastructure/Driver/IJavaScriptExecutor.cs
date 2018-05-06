namespace Typhoon.Infrastructure.Driver
{
    public interface IJavaScriptExecutor
    {
        object ExecuteScript(string script, params object[] args);
    }
}