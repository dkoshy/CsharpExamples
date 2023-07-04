using Generic.App.Entities;

namespace Generic.App.Rpositories
{
    public interface IReadRepository<out T> 
        where T :IEntity
    {
        IEnumerable<T> GetAll();
        T GetById<Tkey>(Tkey key);
    }

    public interface IWriteRepository<in T> where T : IEntity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }

    public interface IRepository<T> : IReadRepository<T> , IWriteRepository<T>
      where T :IEntity
    {
      
    }


}