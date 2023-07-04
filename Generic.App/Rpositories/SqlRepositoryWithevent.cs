using Generic.App.Data;
using Generic.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace Generic.App.Rpositories
{
    public class SqlRepositoryWithevent<T> : IRepository<T>
        where T : class, IEntity<int>, new()
    {
        private readonly SqlInmemmoryDbContext _dbContext;
        private readonly DbSet<T> _dbset;

       

        public SqlRepositoryWithevent(SqlInmemmoryDbContext dbContext )
        {
            _dbContext=dbContext;
            _dbset =_dbContext.Set<T>();
        }

        //public event Action<T> ItemAddedCallback;
        public event EventHandler<T> ItemAddedCallback;

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
            ItemAddedCallback.Invoke(this,item);
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
