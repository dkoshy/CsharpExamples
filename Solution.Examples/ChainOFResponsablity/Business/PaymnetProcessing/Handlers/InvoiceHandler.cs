using ChainOFResponsablity.Business.PaymnetProcessing.Models;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Handlers;

public class InvoiceHandler : PaymentHandler
{
    public InvoiceHandler(IHandler<Order> handler) : base(handler)
    {
    }

    public override void Handle(Order request)
    {
        base.Handle(request);
    }
}
