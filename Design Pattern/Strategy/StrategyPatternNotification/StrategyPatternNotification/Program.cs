using StrategyPatternNotification.Strategies;

namespace StrategyPatternNotification;

class Program
{
    static void Main(string[] args)
    {
        // Create NotificationService (context)
        var notificationService = new NotificationService();
        
        Console.WriteLine("Choose notification type:");
        Console.WriteLine("1. Email");
        Console.WriteLine("2. SMS");
        Console.WriteLine("3. Push");
    
        Console.Write("Enter your choice (1/2/3): ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                notificationService.SetupNotificationStrategy(new EmailNotificationStrategy());
                break;
            case "2":
                notificationService.SetupNotificationStrategy(new SmsNotificationStrategy());
                break;
            case "3":
                notificationService.SetupNotificationStrategy(new PushNotificationStrategy());
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Console.WriteLine("Enter your recipient");
        var recipient = Console.ReadLine();

        Console.WriteLine("Enter your message");
        var message = Console.ReadLine();
        
        notificationService.Notify(message,recipient);
    }
}