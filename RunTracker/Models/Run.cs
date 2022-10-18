namespace RunTracker.Models;

public class Run
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime Date { get; }
    public double Duration { get; }
    public double Distance { get; }
    public double AverageSpeed { get; }
 
    public Run(Guid id, string name, string description, DateTime date, double duration, double distance, 
        double averageSpeed)
    {
        Id = id;
        Name = name;
        Description = description;
        Date = date;
        Duration = duration;
        Distance = distance;
        AverageSpeed = averageSpeed;
    }
}