using ChainOFResponsablity.Business.PaymnetProcessing.Models;

namespace ChainOFResponsablity.Business.PaymnetProcessing.PaymentProcessors;

public interface IPaymentProcessor
{
    void Finalize(Order order);
}
