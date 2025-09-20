using BookyNyShow_LLD.Enums;
using BookyNyShow_LLD.Models;

namespace BookyNyShow_LLD.Interfaces;

public interface IPaymentService
{
    Payment MakePayment(decimal amount, PaymentMode mode);
}