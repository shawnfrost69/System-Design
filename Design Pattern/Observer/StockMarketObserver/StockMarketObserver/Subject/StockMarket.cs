using StockMarketObserver.Interfacea;

namespace StockMarketObserver.Subject;

public class StockMarket : ISubject
{
    private List<IObserver> _observers = new();
    private decimal _price;

    public void SetPrice(decimal newPrice)
    {
        _price = newPrice;
        Console.WriteLine($"\n📈 New Stock Price: ₹{_price}");
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_price);
        }
    }
}