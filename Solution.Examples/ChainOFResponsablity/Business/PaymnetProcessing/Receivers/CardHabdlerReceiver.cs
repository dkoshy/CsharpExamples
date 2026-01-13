using ChainOFResponsablity.Business.PaymnetProcessing.Models;
using ChainOFResponsablity.Business.PaymnetProcessing.PaymentProcessors;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Receivers;

public class CardHabdlerReceiver : IReceiver<Order>
{
    private  readonly CreditCardPaymentProcessor  _CreditCradPaymentProcessor ;
    public CardHabdlerReceiver()
    {
        _CreditCradPaymentProcessor = new CreditCardPaymentProcessor();
    }
    public void Handle(Order request)
    {
        if (request.SelectedPayments.Any(p => p.PaymentProvider == PaymentProvider.CreditCard))
        {
            _CreditCradPaymentProcessor.Finalize(request);
        }

    }

}
