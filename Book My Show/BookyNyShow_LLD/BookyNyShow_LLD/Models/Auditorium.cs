namespace BookyNyShow_LLD.Models;

public class Auditorium
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Theatre Theatre { get; set; }
    public List<Show> Shows { get; set; } = new List<Show>();}