using Parking_lot.Enums;
using Parking_lot.Models;

namespace Parking_lot;

public class NearestSpotStrategy
{
    public (ParkingSpot, Floor) FindSpot(List<Floor> floors, VehicleType type)
    {
        foreach (var floor in floors)
        {
            var spot = floor.Spots.FirstOrDefault(s => 
                !s.IsOccupied && s.SpotType.ToString() == type.ToString());
            if (spot != null)
                return (spot, floor);
        }
        return (null, null);
    }
}