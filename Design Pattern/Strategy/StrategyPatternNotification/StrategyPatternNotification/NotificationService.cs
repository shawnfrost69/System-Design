namespace StrategyPatternNotification;

public class NotificationService
{
    private INotificationStrategy _notificationStrategy;

    //Inject the strategy at Runtime
    public void SetupNotificationStrategy(INotificationStrategy notificationStrategy)
    {
        _notificationStrategy = notificationStrategy;
    }

    public void Notify(string message, string recipient)
    {
        if (_notificationStrategy == null)
        {
            Console.WriteLine("⚠️ No notification strategy set!");
            return;
        }
        
        _notificationStrategy.SendNotification(message, recipient);
    }
}