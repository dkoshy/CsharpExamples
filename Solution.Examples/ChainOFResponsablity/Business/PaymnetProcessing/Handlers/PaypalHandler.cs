using ChainOFResponsablity.Business.PaymnetProcessing.Models;
using ChainOFResponsablity.Business.PaymnetProcessing.PaymentProcessors;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Handlers;

public class PaypalHandler : PaymentHandler
{
    private readonly PaypalPaymentProcessor _paymentProcessor;
    public PaypalHandler()
    {
        _paymentProcessor = new PaypalPaymentProcessor();
    }

    public override void Handle(Order request)
    {
        if(request.SelectedPayments.Any(p=> p.PaymentProvider == PaymentProvider.Paypal))
        {
            _paymentProcessor.Finalize(request);
        }

        base.Handle(request);
    }
}
