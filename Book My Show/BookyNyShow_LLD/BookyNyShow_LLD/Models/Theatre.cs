namespace BookyNyShow_LLD.Models;

public class Theatre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public List<Auditorium> Auditoriums { get; set; } = new();
}