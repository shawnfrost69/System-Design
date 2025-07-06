namespace Parking_lot.Models;

public class Ticket
{
    public Guid TicketId { get; } = Guid.NewGuid();
    public Vehicle Vehicle { get; }
    public ParkingSpot Spot { get; }
    public int FloorNumber { get; }
    public DateTime EntryTime { get; }
    public DateTime? ExitTime { get; set; }

    public Ticket(Vehicle vehicle, ParkingSpot spot, int floorNumber)
    {
        Vehicle = vehicle;
        Spot = spot;
        FloorNumber = floorNumber;
        EntryTime = DateTime.Now;
    }
}