using RunTracker.Models;
using ErrorOr;
using RunTracker.ServiceErrors;

namespace RunTracker.Services.Runs;

public class RunService : IRunService
{
    private static readonly Dictionary<Guid, Run> _runs = new();
    
    public ErrorOr<Created> CreateRun(Run run)
    {
        _runs.Add(run.Id, run);

        return Result.Created;
    }
    
    public ErrorOr<Run> GetRun(Guid id)
    {
        if (_runs.TryGetValue(id, out var run))
        {
            return run;
        }
        
        return Errors.Run.NotFound;
    }

    public Dictionary<Guid, Run> GetRuns()
    {
        return _runs;
    }

    public ErrorOr<Updated> UpdateRun(Run run)
    {
        _runs[run.Id] = run;
        
        return Result.Updated;
    }

    public ErrorOr<Deleted> DeleteRun(Guid id)
    {
        _runs.Remove(id);
        
        return Result.Deleted;
    }
}