using RunTracker.Contracts.Run;
using RunTracker.Models;

namespace RunTracker.Services.Runs;

public interface IRunService
{
    void CreateRun(Run run);
    Run GetRun(Guid Id);
    Dictionary<Guid, Run> GetRuns();

    void UpdateRun(Run run);
    void DeleteRun(Guid id);
}