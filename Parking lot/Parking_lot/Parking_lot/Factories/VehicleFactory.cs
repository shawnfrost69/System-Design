using Parking_lot.Enums;
using Parking_lot.Interface;
using Parking_lot.Models;

namespace Parking_lot.Factories;

public class VehicleFactory : IVehicleFactory
{
    public Vehicle CreateVehicle(string licensePlate, VehicleType type)
    {
        return new Vehicle(licensePlate, type);
    }
}