using ErrorOr;

namespace RunTracker.ServiceErrors;

public static class Errors
{
    public static class Run
    {
        public static Error NotFound => Error.NotFound(
            code: "run.not_found",
            description: "Run not found"
            );
    }
}