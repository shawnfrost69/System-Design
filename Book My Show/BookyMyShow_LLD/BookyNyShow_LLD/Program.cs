using System;
using System.Collections.Generic;
using BookyNyShow_LLD.Models;
using BookyNyShow_LLD.Enums;
using BookyNyShow_LLD.Services;
using BookyNyShow_LLD.Interfaces;

namespace BookyNyShow_LLD
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- Seed data ---
            var movies = new List<Movie>
            {
                new() { Id = 1, Title = "Inception", Language = "English", Genre = "Sci-Fi", DurationInMinutes = 148 },
                new() { Id = 2, Title = "Dangal", Language = "Hindi", Genre = "Drama", DurationInMinutes = 161 }
            };

            var auditorium = new Auditorium { Id = 1, Name = "Screen 1", Shows = new List<Show>() };
            var theatre = new Theatre { Id = 1, Name = "PVR Mall", City = "Mumbai", Auditoriums = new List<Auditorium>{ auditorium } };

            auditorium.Shows.Add(new Show { Id = 1, Movie = movies[0], Auditorium = auditorium, StartTime = DateTime.Now.AddHours(2), Seats = CreateSeats(1, 10) });
            auditorium.Shows.Add(new Show { Id = 2, Movie = movies[1], Auditorium = auditorium, StartTime = DateTime.Now.AddHours(5), Seats = CreateSeats(11, 10) });

            var theatres = new List<Theatre>{ theatre };

            // --- Services ---
            IPaymentService paymentService = new PaymentService();
            var bookingService = new BookingService(paymentService);
            var searchService = new SearchService(movies, theatres);
            bookingService.RegisterObserver(new NotificationService());

            // --- Demo flow ---
            Console.WriteLine("Available Movies:");
            foreach(var m in movies) Console.WriteLine($"{m.Id}. {m.Title}");

            Console.Write("\nSelect Movie Id: ");
            var selectedMovie = movies.Find(m => m.Id == int.Parse(Console.ReadLine() ?? "1"));
            var shows = searchService.GetShows("Mumbai", selectedMovie);

            Console.WriteLine("\nAvailable Shows:");
            foreach(var s in shows) Console.WriteLine($"{s.Id}. {s.Movie.Title} at {s.StartTime}");

            Console.Write("\nSelect Show Id: ");
            var selectedShow = shows.Find(s => s.Id == int.Parse(Console.ReadLine() ?? "1"));

            Console.WriteLine("\nAvailable Seats: " + string.Join(", ", selectedShow.Seats.FindAll(s => s.Status == SeatStatus.AVAILABLE).ConvertAll(s => s.SeatNumber)));
            Console.Write("\nEnter seats (comma separated, e.g., S1,S2): ");
            var seatNumbers = (Console.ReadLine() ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var selectedSeats = selectedShow.Seats.FindAll(s => Array.Exists(seatNumbers, sn => sn.Equals(s.SeatNumber, StringComparison.OrdinalIgnoreCase)));

            var user = new User { Id = 1, Name = "Guest", Bookings = new List<Booking>() };
            var booking = bookingService.CreateBooking(user, selectedShow, selectedSeats);

            Console.Write("\nPayment mode: 1.Card 2.UPI 3.NetBanking 4.Wallet: ");
            var mode = int.Parse(Console.ReadLine() ?? "1") switch
            {
                2 => PaymentMode.UPI,
                3 => PaymentMode.NETBANKING,
                4 => PaymentMode.WALLET,
                _ => PaymentMode.CARD
            };

            var amount = selectedSeats.Count * 250; // price per seat
            bookingService.ConfirmBooking(booking, paymentService.MakePayment(amount, mode));

            Console.WriteLine($"\nBooking {booking.Status} for seats: {string.Join(", ", selectedSeats.ConvertAll(s => s.SeatNumber))}");

            Console.Write("\nCancel booking? (y/n): ");
            if ((Console.ReadLine() ?? "n").Trim().ToLower() == "y")
                bookingService.CancelBooking(booking, true);

            Console.WriteLine("\nSeats after operations:");
            foreach(var seat in selectedShow.Seats) Console.WriteLine($"{seat.SeatNumber} - {seat.Status}");
        }

        private static List<Seat> CreateSeats(int startId, int count)
        {
            var seats = new List<Seat>();
            for (int i = 0; i < count; i++)
                seats.Add(new Seat { Id = startId+i, SeatNumber = $"S{startId+i}", Type = SeatType.REGULAR, Status = SeatStatus.AVAILABLE });
            return seats;
        }
    }
}
