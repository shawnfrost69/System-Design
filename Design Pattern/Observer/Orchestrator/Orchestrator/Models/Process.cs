namespace Orchestrator.Models;

public class Process
{
    public string Id { get; }
    public int Priority { get; set; }
    public DateTime TimeStamp { get; set; }

    public Process(string id, int priority)
    {
        Id = id;
        Priority = priority;
        TimeStamp = DateTime.UtcNow;
    }
}