using DesignPatternChallenge.Legacy;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.Interfaces;

namespace DesignPatternChallenge.Adapters;

public class LegacyPaymentAdapter(LegacyPaymentSystem legacySystem) : IPaymentProcessor
{
    private readonly LegacyPaymentSystem _legacySystem = legacySystem;
    
    public PaymentResult ProcessPayment(PaymentRequest request)
    {
        var cvvCode = int.Parse(request.Cvv);
        var expMonth = request.ExpirationDate.Month;
        var expYear = request.ExpirationDate.Year;
        var amountInCents = (double)(request.Amount * 100);

        var legacyResponse = _legacySystem.AuthorizeTransaction(
            request.CreditCardNumber,
            cvvCode,
            expMonth,
            expYear,
            amountInCents,
            request.CustomerEmail);

        return new PaymentResult
        {
            Success = legacyResponse.ResponseCode == "00",
            TransactionId = legacyResponse.TransactionRef,
            Message = legacyResponse.ResponseMessage,
        };
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
        var amountInCents = (double)(amount * 100);
        return _legacySystem.ReverseTransaction(transactionId, amountInCents);
    }

    public PaymentStatus CheckStatus(string transactionId)
    {
        var legacyStatus = _legacySystem.QueryTransactionStatus(transactionId);

        return legacyStatus switch
        {
            "APPROVED" => PaymentStatus.Approved,
            "DECLINED" => PaymentStatus.Declined,
            "REFUNDED" => PaymentStatus.Refunded,
            _ => PaymentStatus.Pending
        };
    }
}