using ChainOFResponsablity.Business.PaymnetProcessing.Models;
using ChainOFResponsablity.Business.PaymnetProcessing.PaymentProcessors;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Receivers;

public class InvoiceHandlerReceiver : IReceiver<Order>
{
    private InvoicePaymentProcessor _paymentProcessor;
    public void Handle(Order order)
    {
        _paymentProcessor = new InvoicePaymentProcessor();

        if(order.SelectedPayments.Any(p => p.PaymentProvider == PaymentProvider.Invoice))
        {
            _paymentProcessor.Finalize(order);
        }
    }
}
