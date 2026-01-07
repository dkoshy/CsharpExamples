using ChainOFResponsablity.Business.PaymnetProcessing.Models;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Handlers;

public abstract class PaymentHandler : IHandler<Order>
{
    private  IHandler<Order> _handler;

    public PaymentHandler(IHandler<Order> handler)
    {
        _handler = handler;
    }
    public virtual void Handle(Order request)
    {
        _handler.Handle(request);
    }

    public IHandler<Order> SetNext(IHandler<Order> nextHandler)
    {
       _handler = nextHandler ?? throw new ArgumentNullException(nameof(nextHandler));
        return _handler;
    }
}
