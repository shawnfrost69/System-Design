namespace StrategyPatternNotification.Strategies;

public class PushNotificationStrategy: INotificationStrategy
{
    public void SendNotification(string message, string recipient)
    {
        Console.WriteLine($"🔔 Sending PUSH to {recipient}: {message}");
    }
}