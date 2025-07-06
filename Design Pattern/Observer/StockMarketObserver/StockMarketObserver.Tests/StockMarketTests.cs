using System;
using System.IO;
using StockMarketObserver.Observers;
using StockMarketObserver.Subject;
using Xunit;
using Assert = Xunit.Assert;

public class StockMarketTests
{
    [Fact]
    public void NotifyObservers_ShouldNotifyAllObservers()
    {
        var stockMarket = new StockMarket();
        var writer = new StringWriter();
        Console.SetOut(writer);

        stockMarket.RegisterObserver(new MobileApp());
        stockMarket.RegisterObserver(new TradingBot());

        stockMarket.SetPrice(200.0m);

        var output = writer.ToString();
        Assert.Contains("📱 Mobile App - New stock price: 200", output);
        Assert.Contains("🤖 Trading Bot - Evaluating new price: 200", output);
    }
}