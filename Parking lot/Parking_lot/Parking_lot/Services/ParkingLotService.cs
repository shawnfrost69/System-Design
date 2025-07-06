using Parking_lot.Models;

namespace Parking_lot.Services;

public class ParkingLotService
{
    private List<Floor> _floors;
    private List<Ticket> _tickets = new();
    private NearestSpotStrategy _strategy = new();

    public ParkingLotService(List<Floor> floors)
    {
        _floors = floors;
    }

    public Ticket ParkVehicle(Vehicle vehicle)
    {
        var (spot, floor) = _strategy.FindSpot(_floors, vehicle.Type);
        if (spot == null) throw new Exception("No available spot!");

        spot.IsOccupied = true;
        spot.Vehicle = vehicle;

        var ticket = new Ticket(vehicle, spot, floor.FloorNumber);
        _tickets.Add(ticket);
        return ticket;
    }

    public double UnparkVehicle(Guid ticketId)
    {
        var ticket = _tickets.First(t => t.TicketId == ticketId);
        ticket.ExitTime = DateTime.Now;

        ticket.Spot.IsOccupied = false;
        ticket.Spot.Vehicle = null;

        var paymentService = new PaymentService();
        return paymentService.CalculatePayment(ticket);
    }
}