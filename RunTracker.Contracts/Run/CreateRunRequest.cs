namespace RunTracker.Contracts.Run;

public record CreateRunRequest(
    string Name,
    string Description,
    DateTime Date,
    double Duration,
    double Distance,
    double AverageSpeed
    );