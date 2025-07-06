using Parking_lot.Enums;
using Parking_lot.Models;
using Parking_lot.Services;

namespace Parking_lot;

class Program
{
    static void Main(string[] args)
    {
        var floor1 = new Floor(1);
        floor1.Spots.Add(new ParkingSpot(1, SpotType.Car));
        floor1.Spots.Add(new ParkingSpot(2, SpotType.Bike));

        var floor2 = new Floor(2);
        floor2.Spots.Add(new ParkingSpot(3, SpotType.Car));
        floor2.Spots.Add(new ParkingSpot(4, SpotType.Bike));

        var parkingLot = new ParkingLotService(new List<Floor> { floor1, floor2 });

        var factory = new VehicleFactory();
        var vehicle = factory.CreateVehicle("MH12AB1234", VehicleType.Car);

        // Park
        var ticket = parkingLot.ParkVehicle(vehicle);
        Console.WriteLine($"Parked at Floor {ticket.FloorNumber}, Spot {ticket.Spot.Id}");

        // Simulate delay
        System.Threading.Thread.Sleep(2000);

        // Unpark
        var fee = parkingLot.UnparkVehicle(ticket.TicketId);
        Console.WriteLine($"Unparked. Pay ₹{fee}");
    }
}