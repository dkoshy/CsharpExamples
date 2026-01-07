namespace ChainOFResponsablity.Business.PaymnetProcessing.Handlers;

public  interface IHandler<T> where T : class
{
     void Handle(T request);
     IHandler<T> SetNext(IHandler<T> handler);

}
