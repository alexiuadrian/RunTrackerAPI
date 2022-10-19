using RunTracker.Contracts.Run;
using RunTracker.Models;
using ErrorOr;

namespace RunTracker.Services.Runs;

public interface IRunService
{
    ErrorOr<Created> CreateRun(Run run);
    ErrorOr<Run> GetRun(Guid Id);
    Dictionary<Guid, Run> GetRuns();

    ErrorOr<Updated> UpdateRun(Run run);
    ErrorOr<Deleted> DeleteRun(Guid id);
}