using ChainOFResponsablity.Business.PaymnetProcessing.Exceptions;
using ChainOFResponsablity.Business.PaymnetProcessing.Models;
using ChainOFResponsablity.Business.PaymnetProcessing.Receivers;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Handlers;

public class PaymentHandlerWithReceiveers
{
    private IList<IReceiver<Order>> _receivers;

    public PaymentHandlerWithReceiveers(params IReceiver<Order>[] receivers)
    {
        _receivers = receivers.ToList();
    }
    public  void Handle(Order request)
    {
        foreach(var receiver in _receivers)
        {
            Console.WriteLine($"Running: {receiver.GetType().Name}");

           if(request.AmountDue > 0  && receiver != null)
            {
                receiver.Handle(request);
            }
            else
            {
                break;
            }

        }

        if(request.AmountDue > 0)
        {
            throw new InsufficientPaymentException();
        }
        else
        {
            request.ShippingStatus = ShippingStatus.ReadyForShippment;
        }

    }

    public void Addreceiver(IReceiver<Order> receiver)
    {
        _receivers.Add(receiver ?? throw new ArgumentNullException(nameof(receiver)));
    }
}
