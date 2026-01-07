namespace ChainOFResponsablity.Business.PaymnetProcessing.Models;

public class Payment
{
    public decimal Amount { get; set; }
    public PaymentProvider PaymentProvider { get; set; }
}