namespace RunTracker.Contracts.Run;

public record RunResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime Date,
    double Duration,
    double Distance,
    double AverageSpeed
    );