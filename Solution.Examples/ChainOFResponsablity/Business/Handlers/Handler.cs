namespace ChainOFResponsablity.Business.Handlers;


public interface IHandler<T> where T:class
{
    void Handle(T request);
    IHandler<T> SetNext(IHandler<T> next);
}

public abstract class Handler<T> : IHandler<T> where T : class
{
    private  IHandler<T>? nextHandler;
    public virtual void Handle(T request)
    {
        nextHandler?.Handle(request);
    }

    public IHandler<T> SetNext(IHandler<T> next)
    {
        nextHandler = next;
        return nextHandler;
    }
}


