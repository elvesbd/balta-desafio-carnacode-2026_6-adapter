namespace DesignPatternChallenge.Legacy;

public class LegacyTransactionResponse
{
    public string AuthCode { get; set; } = string.Empty;
    public string ResponseCode { get; set; } = string.Empty;
    public string ResponseMessage { get; set; } = string.Empty;
    public string TransactionRef { get; set; } = string.Empty;
}