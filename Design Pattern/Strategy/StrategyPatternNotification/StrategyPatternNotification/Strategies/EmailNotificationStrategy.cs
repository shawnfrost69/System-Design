namespace StrategyPatternNotification.Strategies;

public class EmailNotificationStrategy : INotificationStrategy
{
    public void SendNotification(string message, string recipient)
    {
        Console.WriteLine(($"Sending EMAIL to {recipient}: {message}"));
    }
}