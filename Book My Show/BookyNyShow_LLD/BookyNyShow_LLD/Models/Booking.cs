using BookyNyShow_LLD.Enums;

namespace BookyNyShow_LLD.Models;

public class Booking
{
    public int Id { get; set; }
    public User User { get; set; }
    public Show Show { get; set; }
    public List<Seat> Seats { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.AVAILABLE;
    public Payment Payment { get; set; }
}