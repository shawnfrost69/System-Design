using Parking_lot.Models;

namespace Parking_lot.Services;

public class PaymentService
{
    public double CalculatePayment(Ticket ticket)
    {
        var duration = (ticket.ExitTime.Value - ticket.EntryTime).TotalHours;
        return Math.Ceiling(duration) * 10; 
    }
}