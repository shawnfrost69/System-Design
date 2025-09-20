using BookyNyShow_LLD.Enums;
using BookyNyShow_LLD.Interfaces;
using BookyNyShow_LLD.Models;

public class BookingService
{
    private int _bookingIdCounter = 1;
    private readonly List<IBookingObserver> _observers = new();
    private readonly IPaymentService _paymentService;

    public BookingService(IPaymentService paymentService)
    {
        _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
    }

    public Booking CreateBooking(User user, Show show, List<Seat> seats)
    {
        foreach (var seat in seats)
        {
            if (seat.Status != SeatStatus.AVAILABLE)
                throw new Exception($"Seat {seat.SeatNumber} is not available");
            seat.Status = SeatStatus.BOOKED;
        }

        var booking = new Booking { Id = _bookingIdCounter++, User = user, Show = show, Seats = seats };
        user.Bookings.Add(booking);
        return booking;
    }

    public void RegisterObserver(IBookingObserver observer)
    {
        if (observer != null && !_observers.Contains(observer))
            _observers.Add(observer);
    }

    private void NotifyObservers(Booking booking)
    {
        foreach (var obs in _observers)
        {
            try { obs.Update(booking, $"Booking {booking.Status}"); } catch { }
        }
    }

    public void ConfirmBooking(Booking booking, Payment payment)
    {
        if (payment.Status == PaymentStatus.SUCCESS)
        {
            booking.Status = BookingStatus.CONFIRMED;
            booking.Payment = payment;
            foreach (var seat in booking.Seats)
                seat.Status = SeatStatus.BOOKED;
        }
        else
        {
            booking.Status = BookingStatus.CANCELLED;
            foreach (var seat in booking.Seats)
                seat.Status = SeatStatus.AVAILABLE;
        }

        NotifyObservers(booking);
    }

    public bool CancelBooking(Booking booking, bool refund = true)
    {
        if (booking == null || booking.Status == BookingStatus.CANCELLED)
            return false;

        if (DateTime.Now > booking.Show.StartTime.AddMinutes(-30))
        {
            Console.WriteLine("Cancellation window has closed (30 minutes before show).");
            return false;
        }

        foreach (var seat in booking.Seats)
            seat.Status = SeatStatus.AVAILABLE;

        booking.Status = BookingStatus.CANCELLED;

        if (refund && booking.Payment != null)
        {
            try
            {
                var success = _paymentService.Refund(booking.Payment);
                Console.WriteLine(success ? "Refund successful (demo)." : "Refund failed (demo).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Refund error: {ex.Message}");
            }
        }

        NotifyObservers(booking);
        return true;
    }
}
