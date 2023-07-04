using Generic.App.Data;
using Generic.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace Generic.App.Rpositories
{
    // public delegate void ItemAdded(IEntity item);
    public class SqlRepositoryWitDelegate<T> : IRepository<T>
        where T : class, IEntity<int>, new()
    {
        private readonly SqlInmemmoryDbContext _dbContext;
        //private readonly ItemAdded _itemAddedCallback;
        private readonly Action<T> _itemAddedCallback;
        private readonly DbSet<T> _dbset;

        public SqlRepositoryWitDelegate(SqlInmemmoryDbContext dbContext , Action<T> itemAddedCallback)
        {
            _dbContext=dbContext;
            _itemAddedCallback=itemAddedCallback;
            _dbset =_dbContext.Set<T>();
        }

        public T GetById<Tkey>(Tkey key)
        {
            var item = _dbset.SingleOrDefault(t => t.Id.Equals(key));
            if (item == null)
                return new T();
            return item;
        }

        public void Add(T item)
        {
            _dbset.Add(item);
            _itemAddedCallback.Invoke(item);
        }

        public void Remove(T item)
        {
            _dbset.Remove(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset
                 .OrderBy(t => t.Id)
                .ToList();
        }
    }
}
