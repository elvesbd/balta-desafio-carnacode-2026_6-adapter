using DesignPatternChallenge.Adapters;
using DesignPatternChallenge.Legacy;
using DesignPatternChallenge.Services;

Console.WriteLine("=== Sistema de Checkout - Adapter Pattern ===\n");

Console.WriteLine("--- Processador Moderno ---");
var moderProcessor = new ModernPaymentProcessor();
var checkoutModern = new CheckoutService(moderProcessor);
checkoutModern.CompleteOrder("cliente@email.com", 150.00m, "4111111111111111");

Console.WriteLine("\n" + new string('-', 60));

Console.WriteLine("\n--- Sistema Legado via Adapter ---");
var legacySystem = new LegacyPaymentSystem();
var legacyAdapter = new LegacyPaymentAdapter(legacySystem);
var checkoutLegacy = new CheckoutService(legacyAdapter);
checkoutLegacy.CompleteOrder("cliente2@email.com", 200.00m, "5500000000000004");

Console.WriteLine("\n" + new string('-', 60));

Console.WriteLine("\n--- Refund e Status via Adapter ---\n");
var refundResult = legacyAdapter.RefundPayment("LEG123456", 50.00m);
Console.WriteLine($"Refund realizado: {refundResult}");

Console.WriteLine();
var status = legacyAdapter.CheckStatus("LEG123456");
Console.WriteLine($"Status da transação: {status}");