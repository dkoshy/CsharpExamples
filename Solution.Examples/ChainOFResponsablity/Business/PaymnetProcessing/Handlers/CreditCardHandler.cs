using ChainOFResponsablity.Business.PaymnetProcessing.Models;
using ChainOFResponsablity.Business.PaymnetProcessing.PaymentProcessors;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Handlers;

public class CreditCardHandler : PaymentHandler
{
    private readonly CreditCardPaymentProcessor _paymentProcessor;

    public CreditCardHandler() 
    {
        _paymentProcessor = new CreditCardPaymentProcessor();
    }

    public override void Handle(Order request)
    {
        if(request.SelectedPayments.Any(p=> p.PaymentProvider == PaymentProvider.CreditCard))
        {
            _paymentProcessor.Finalize(request);

        }
        base.Handle(request);
    }

}
