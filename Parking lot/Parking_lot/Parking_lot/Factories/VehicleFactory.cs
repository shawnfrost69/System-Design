using Parking_lot.Enums;
using Parking_lot.Interface;
using Parking_lot.Models;

namespace Parking_lot.Factories;

public class VehicleFactory : IVehicleFactory
{
    public Vehicle CreateVehicle(string licensePlate, VehicleType type)
    {
        // You can add more validations or different subtypes here
        return new Vehicle(licensePlate, type);
    }
}