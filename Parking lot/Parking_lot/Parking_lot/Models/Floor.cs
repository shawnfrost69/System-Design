namespace Parking_lot.Models;

public class Floor
{
    public int FloorNumber { get; }
    public List<ParkingSpot> Spots { get; }

    public Floor(int number)
    {
        FloorNumber = number;
        Spots = new List<ParkingSpot>();
    }
}