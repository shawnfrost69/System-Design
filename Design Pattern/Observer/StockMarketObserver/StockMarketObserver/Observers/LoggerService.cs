using StockMarketObserver.Interfacea;

namespace StockMarketObserver.Observers;

public class LoggerService : IObserver
{
    public void Update(decimal price)
    {
        Console.WriteLine($"📋 Logger - Stock price logged: {price}");
    }
}