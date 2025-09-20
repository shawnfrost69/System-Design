using BookyNyShow_LLD.Enums;
using BookyNyShow_LLD.Interfaces;
using BookyNyShow_LLD.Models;

namespace BookyNyShow_LLD.Services;

public class PaymentService : IPaymentService
{
    private int _paymentIdCounter = 1;
    private readonly Random _random = new();

    public Payment MakePayment(decimal amount, PaymentMode mode)
    {
        if (amount <= 0)
            throw new ArgumentException("Invalid payment amount");

        var isSuccess = _random.Next(0, 100) < 90; // 90% chance success

        return new Payment()
        {
            Id = _paymentIdCounter++,
            Amount = amount,
            Mode = mode,
            Status = isSuccess ? PaymentStatus.SUCCESS : PaymentStatus.FAILED
        };
    }
    public bool Refund(Payment payment)
    {
        if (payment == null) return false;

        // For demo: always succeed refund (or simulate failure if desired)
        Console.WriteLine($"Processing refund for PaymentId: {payment.Id}, Amount: {payment.Amount}");
        return true;
    }
}
