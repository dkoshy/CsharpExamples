using ChainOFResponsablity.Business.PaymnetProcessing.Models;

namespace ChainOFResponsablity.Business.PaymnetProcessing.Receivers;

public interface IReceiver<T> where T : class
{
    void Handle(Order request);
}
