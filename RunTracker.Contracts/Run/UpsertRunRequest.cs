namespace RunTracker.Contracts.Run;

public record UpsertRunRequest(
    string Name,
    string Description,
    DateTime Date,
    double Duration,
    double Distance,
    double AverageSpeed
);