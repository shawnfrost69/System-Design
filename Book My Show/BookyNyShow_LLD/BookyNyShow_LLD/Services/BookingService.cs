using BookyNyShow_LLD.Enums;
using BookyNyShow_LLD.Models;

namespace BookyNyShow_LLD.Services;

public class BookingService
{
    private int _bookingIdCounter = 1;

    public Booking CreateBooking(User user, Show show, List<Seat> seats)
    {
        //block seats
        foreach (var seat in seats)
        {
            if (seat.Status != SeatStatus.AVAILABLE)
            {
                throw new Exception($"Seat {seat.SeatNumber} is not available");
            }

            seat.Status = SeatStatus.BOOKED;
        }

        var booking = new Booking()
        {
            Id = _bookingIdCounter++,
            User = user,
            Show = show,
            Seats = seats
        };
        
        user.Bookings.Add(booking);
        return booking;
    }

    public void ConfirmBooking(Booking booking, Payment payment)
    {
        if (payment.Status == PaymentStatus.SUCCESS)
        {
            booking.Status = BookingStatus.CONFIRMED;
            booking.Payment = payment;
            
            foreach (var seat in booking.Seats)
            {
                seat.Status = SeatStatus.BOOKED;
            }
        }
        else
        {
            booking.Status = BookingStatus.CANCELLED;
            foreach (var seat in booking.Seats)
            {
                seat.Status = SeatStatus.AVAILABLE;
            }
        }
    }
}