namespace StockMarketObserver.Interfacea;

public interface IObserver
{
    void Update(decimal price);
}