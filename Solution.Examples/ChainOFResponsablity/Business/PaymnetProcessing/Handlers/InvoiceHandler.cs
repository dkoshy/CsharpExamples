using ChainOFResponsablity.Business.PaymnetProcessing.Models;
using ChainOFResponsablity.Business.PaymnetProcessing.PaymentProcessors;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Handlers;

public class InvoiceHandler : PaymentHandler
{
    private readonly InvoicePaymentProcessor _paymentProcessor;
    public InvoiceHandler() 
    {
        _paymentProcessor = new InvoicePaymentProcessor();
    }

    public override void Handle(Order request)
    {
        if (request.SelectedPayments.Any(p => p.PaymentProvider == PaymentProvider.Invoice))
        {
            _paymentProcessor.Finalize(request);
        }
         base.Handle(request);
    }
}
