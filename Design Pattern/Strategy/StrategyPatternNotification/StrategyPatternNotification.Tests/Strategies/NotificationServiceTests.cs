using StrategyPatternNotification.Strategies;

namespace StrategyPatternNotification.Tests;

public class NotificationServiceTests
{
    [Fact]
    public void TestEmailNotificationStrategy()
    {
        //Arrange
        var service = new NotificationService();
        service.SetupNotificationStrategy(new EmailNotificationStrategy());

        var writer = new StringWriter();
        Console.SetOut(writer);
        
        //Act
        service.Notify("Test Email", "test@example.com");
        
        //Assert
        var output = writer.ToString().Trim();
        Assert.Equal("Sending EMAIL to test@example.com: Test Email", output);
    }
    
    [Fact]
    public void TestSMSNotification()
    {
        var service = new NotificationService();
        service.SetupNotificationStrategy(new SmsNotificationStrategy());

        var writer = new StringWriter();
        Console.SetOut(writer);

        service.Notify("Test SMS", "+123456789");
        var output = writer.ToString().Trim();

        Assert.Equal("📱 Sending SMS to +123456789: Test SMS", output);
    }

    [Fact]
    public void TestPushNotification()
    {
        var service = new NotificationService();
        service.SetupNotificationStrategy(new PushNotificationStrategy());

        var writer = new StringWriter();
        Console.SetOut(writer);

        service.Notify("Test PushNotification", "987654321");
        var output = writer.ToString().Trim();

        Assert.Equal("🔔 Sending PUSH to 987654321: Test PushNotification", output);
    }
}