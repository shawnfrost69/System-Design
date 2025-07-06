using Parking_lot.Enums;

namespace Parking_lot.Models;
public class Vehicle
{
    public string LicensePlate { get; }
    public VehicleType Type { get; }

    public Vehicle(string plate, VehicleType type)
    {
        LicensePlate = plate;
        Type = type;
    }
}

// Factories/VehicleFactory.cs
public class VehicleFactory
{
    public Vehicle CreateVehicle(string licensePlate, VehicleType type)
    {
        return new Vehicle(licensePlate, type);
    }
}
