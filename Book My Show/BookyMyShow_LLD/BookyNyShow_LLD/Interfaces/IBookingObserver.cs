using BookyNyShow_LLD.Models;

namespace BookyNyShow_LLD.Interfaces;

public interface IBookingObserver
{
    void Update(Booking booking, string message);
}
