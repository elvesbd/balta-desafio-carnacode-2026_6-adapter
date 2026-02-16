namespace DesignPatternChallenge.Legacy;

public class LegacyPaymentSystem
{
    public LegacyTransactionResponse AuthorizeTransaction(
        string cardNum,
        int cvvCode,
        int expMonth,
        int expYear,
        double amountInCents,
        string customerInfo)
    {
        Console.WriteLine("[Sistema Legado] Autorizando transação...");
        Console.WriteLine($"   Cartão: {cardNum}");
        Console.WriteLine($"   Valor: {amountInCents / 100:C}");

        return new LegacyTransactionResponse
        {
            AuthCode = Guid.NewGuid().ToString()[..8].ToUpper(),
            ResponseCode = "00",
            ResponseMessage = "TRANSACTION APPROVED",
            TransactionRef = $"LEG{DateTime.Now.Ticks}"
        };
    }

    public bool ReverseTransaction(string transRef, double amountInCents)
    {
        Console.WriteLine($"[Sistema Legado] Revertendo transação {transRef}");
        Console.WriteLine($"   Valor: {amountInCents / 100:C}");
        return true;
    }

    public string QueryTransactionStatus(string transRef)
    {
        Console.WriteLine($"[Sistema Legado] Consultando transação {transRef}");
        return "APPROVED";
    }
}