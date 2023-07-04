using Generic.App.Entities;

namespace Generic.App.Rpositories
{
    public class ListRepository<T> : IRepository<T>
        where T : class,IEntity<int>, new()
    {
        protected readonly List<T> items = new();

        public T GetById<Tkey>(Tkey key)
        {
            var item = items.SingleOrDefault(t => t.Id.Equals(key));
            if (item == null)
                return new T();
            return item;
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public void Save()
        {

        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }
    }
}
