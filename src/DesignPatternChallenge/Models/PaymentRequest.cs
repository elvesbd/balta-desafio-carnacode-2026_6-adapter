namespace DesignPatternChallenge.Models;

public class PaymentRequest
{
    public string CustomerEmail { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string CreditCardNumber { get; set; } = string.Empty;
    public string Cvv { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public string Description { get; set; } = string.Empty;
}