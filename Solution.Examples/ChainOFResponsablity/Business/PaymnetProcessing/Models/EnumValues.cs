namespace ChainOFResponsablity.Business.PaymnetProcessing.Models;

public enum ShippingStatus
{
    WaitingForPayment,
    ReadyForShippment,
    Shipped
}

public enum PaymentProvider
{
    Paypal,
    CreditCard,
    Invoice
}
