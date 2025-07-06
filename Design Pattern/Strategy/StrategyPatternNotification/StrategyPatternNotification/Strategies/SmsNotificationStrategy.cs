namespace StrategyPatternNotification.Strategies;

public class SmsNotificationStrategy: INotificationStrategy
{
    public void SendNotification(string message, string recipient)
    {
        Console.WriteLine($"📱 Sending SMS to {recipient}: {message}");
    }
}