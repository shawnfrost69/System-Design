using Parking_lot.Enums;

namespace Parking_lot.Models;

public class ParkingSpot
{
    public int Id { get; }
    public SpotType SpotType { get; }
    public bool IsOccupied { get; set; }
    public Vehicle Vehicle { get; set; }

    public ParkingSpot(int id, SpotType type)
    {
        Id = id;
        SpotType = type;
        IsOccupied = false;
    }
}