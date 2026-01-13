using ChainOFResponsablity.Business.PaymnetProcessing.Exceptions;
using ChainOFResponsablity.Business.PaymnetProcessing.Models;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Handlers;

public abstract class PaymentHandler : IHandler<Order>
{
    private  IHandler<Order>? _handler;
   
    public virtual void Handle(Order request)
    {
        Console.WriteLine($"Running:  {GetType().Name} ");

        if(_handler ==  null && request.AmountDue > 0)
        {
            throw new InsufficientPaymentException();
        }
        if(request.AmountDue > 0)
        {
            _handler?.Handle(request);
        }
        else
        {
            request.ShippingStatus = ShippingStatus.ReadyForShippment;
        }
    }

    public IHandler<Order> SetNext(IHandler<Order> nextHandler)
    {
       _handler = nextHandler ?? throw new ArgumentNullException(nameof(nextHandler));
       return _handler;
    }
}
