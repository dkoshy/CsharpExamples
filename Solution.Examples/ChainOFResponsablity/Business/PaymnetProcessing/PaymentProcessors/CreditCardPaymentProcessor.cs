using ChainOFResponsablity.Business.PaymnetProcessing.Models;

namespace ChainOFResponsablity.Business.PaymnetProcessing.PaymentProcessors;

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void Finalize(Order order)
    {
        // Invoke the Stripe API
        var payment = order.SelectedPayments
            .FirstOrDefault(x => x.PaymentProvider == PaymentProvider.CreditCard);

        if (payment == null) return;

        order.FinalizedPayments.Add(payment);
    }
}
