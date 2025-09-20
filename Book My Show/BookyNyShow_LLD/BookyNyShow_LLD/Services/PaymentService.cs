using BookyNyShow_LLD.Enums;
using BookyNyShow_LLD.Models;

namespace BookyNyShow_LLD.Services;

public class PaymentService
{
    private int _paymentIdCounter = 0;

    public Payment MakePayment(decimal amount, PaymentMode mode)
    {
        return new Payment()
        {
            Id = _paymentIdCounter++,
            Amount = amount,
            Mode = mode,
            Status = PaymentStatus.SUCCESS
        };
    }
}