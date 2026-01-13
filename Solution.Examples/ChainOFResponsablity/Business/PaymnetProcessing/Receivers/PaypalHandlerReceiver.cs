using ChainOFResponsablity.Business.PaymnetProcessing.Models;
using ChainOFResponsablity.Business.PaymnetProcessing.PaymentProcessors;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Receivers;

public class PaypalHandlerReceiver : IReceiver<Order>
{
    private  PaypalPaymentProcessor _PaymentProcessor;

    public void Handle(Order request)
    {
        _PaymentProcessor = new PaypalPaymentProcessor();
        if (request.SelectedPayments.Any(p => p.PaymentProvider == PaymentProvider.Paypal))
        {
            _PaymentProcessor.Finalize(request);
        }
    }

}
