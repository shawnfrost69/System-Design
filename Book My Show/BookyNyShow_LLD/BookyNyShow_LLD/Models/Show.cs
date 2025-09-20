namespace BookyNyShow_LLD.Models;

public class Show
{
    public int Id { get; set; }
    public Movie Movie { get; set; }
    public Auditorium Auditorium { get; set; }
    public DateTime StartTime { get; set; }
    public List<Seat> Seats { get; set; }
}