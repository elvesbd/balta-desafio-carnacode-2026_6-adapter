using DesignPatternChallenge.Models;
using DesignPatternChallenge.Interfaces;

namespace DesignPatternChallenge.Services;

public class CheckoutService(IPaymentProcessor paymentProcessor)
{
    private readonly IPaymentProcessor _paymentProcessor = paymentProcessor;

    public void CompleteOrder(string customerEmail, decimal amount, string cardNumber)
    {
        Console.WriteLine($"\n=== Finalizando Pedido ===");
        Console.WriteLine($"Cliente: {customerEmail}");
        Console.WriteLine($"Valor: {amount:C}\n");

        var request = new PaymentRequest
        {
            CustomerEmail = customerEmail,
            Amount = amount,
            CreditCardNumber = cardNumber,
            Cvv = "123",
            ExpirationDate = new DateTime(2026, 12, 31),
            Description = "Compra de produtos"
        };

        var result = _paymentProcessor.ProcessPayment(request);

        Console.WriteLine(result.Success
            ? $"✅ Pedido aprovado! ID: {result.TransactionId}"
            : $"❌ Pagamento recusado: {result.Message}");
    }
}