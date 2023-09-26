namespace Design.Patterns.ChainofResponsiblity.Validation
{
    public interface IHandler<T> where T: class
    {
        IHandler<T> SetNext(IHandler<T> next);
        void Handle(T data);

    }
    public class Handler<T> : IHandler<T> where T : class
    {
        private IHandler<T> Next { get; set; }
        public virtual void Handle(T data)
        {
            Next?.Handle(data);
        }

       public IHandler<T> SetNext(IHandler<T> next)
        {
            Next = next;
            return next;
        }
    }
}
