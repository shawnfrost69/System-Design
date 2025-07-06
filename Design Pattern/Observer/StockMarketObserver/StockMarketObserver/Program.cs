using StockMarketObserver.Observers;
using StockMarketObserver.Subject;

namespace StockMarketObserver;

class Program
{
    static void Main(string[] args)
    {
        var stockMarket = new StockMarket();

        var mobileApp = new MobileApp();
        var tradingBot = new TradingBot();
        var logger = new LoggerService();

        // Register all observers
        stockMarket.RegisterObserver(mobileApp);
        stockMarket.RegisterObserver(tradingBot);
        stockMarket.RegisterObserver(logger);

        // Initial notification
        stockMarket.SetPrice(125.75m);

        // Remove logger and send another update
        stockMarket.RemoveObserver(logger);

        Console.WriteLine("\n🚫 LoggerService unsubscribed.\n");

        stockMarket.SetPrice(127.25m);
    }
}