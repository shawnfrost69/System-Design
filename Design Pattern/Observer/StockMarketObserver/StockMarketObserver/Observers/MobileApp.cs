using StockMarketObserver.Interfacea;

namespace StockMarketObserver.Observers;

public class MobileApp : IObserver
{
    public void Update(decimal price)
    {
        Console.WriteLine($"📱 Mobile App - New stock price: {price}");
    }
}