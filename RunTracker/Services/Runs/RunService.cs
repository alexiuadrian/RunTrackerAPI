using RunTracker.Models;

namespace RunTracker.Services.Runs;

public class RunService : IRunService
{
    private static readonly Dictionary<Guid, Run> _runs = new();
    
    public void CreateRun(Run run)
    {
        _runs.Add(run.Id, run);
    }
    
    public Run GetRun(Guid id)
    {
        return _runs[id];
    }

    public Dictionary<Guid, Run> GetRuns()
    {
        return _runs;
    }

    public void UpdateRun(Run run)
    {
        _runs[run.Id] = run;
    }

    public void DeleteRun(Guid id)
    {
        _runs.Remove(id);
    }
}