using System;
using System.Linq;
using BookyNyShow_LLD.Models;
using BookyNyShow_LLD.Enums;
using BookyNyShow_LLD.Interfaces;

namespace BookyNyShow_LLD.Services
{
    public class NotificationService : IBookingObserver
    {
        public void Update(Booking booking, string message)
        {
            if (booking == null) return;

            if (booking.Status == BookingStatus.CONFIRMED)
            {
                Console.WriteLine($"\n📩 Notification: Dear {booking.User?.Name ?? "User"}, your booking #{booking.Id} for '{booking.Show.Movie.Title}' is CONFIRMED. Seats: {string.Join(", ", booking.Seats.Select(s => s.SeatNumber))}");
            }
            else if (booking.Status == BookingStatus.CANCELLED)
            {
                Console.WriteLine($"\n📩 Notification: Dear {booking.User?.Name ?? "User"}, your booking #{booking.Id} for '{booking.Show.Movie.Title}' is CANCELLED.");
            }
        }
    }
}