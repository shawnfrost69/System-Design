using Parking_lot.Enums;
using Parking_lot.Models;

namespace Parking_lot.Interface;

public interface IVehicleFactory
{
    Vehicle CreateVehicle(string licensePlate, VehicleType type);
}