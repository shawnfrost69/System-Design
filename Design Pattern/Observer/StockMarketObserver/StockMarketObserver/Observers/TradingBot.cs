using StockMarketObserver.Interfacea;

namespace StockMarketObserver.Observers;

public class TradingBot : IObserver
{
    public void Update(decimal price)
    {
        Console.WriteLine($"🤖 Trading Bot - Evaluating new price: {price}");
    }
}