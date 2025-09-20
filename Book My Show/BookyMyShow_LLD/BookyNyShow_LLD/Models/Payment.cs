using BookyNyShow_LLD.Enums;

namespace BookyNyShow_LLD.Models;

public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    public PaymentMode Mode { get; set; }
}