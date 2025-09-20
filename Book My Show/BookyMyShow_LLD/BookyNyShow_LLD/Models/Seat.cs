using BookyNyShow_LLD.Enums;

namespace BookyNyShow_LLD.Models;

public class Seat
{
    public int Id { get; set; }
    public string SeatNumber { get; set; }
    public SeatType Type { get; set; }
    public SeatStatus Status { get; set; } = SeatStatus.AVAILABLE;
}