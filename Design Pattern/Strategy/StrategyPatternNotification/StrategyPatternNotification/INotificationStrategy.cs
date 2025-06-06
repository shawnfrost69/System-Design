namespace StrategyPatternNotification;

public interface INotificationStrategy
{
    void SendNotification(string message, string recipient);   
}