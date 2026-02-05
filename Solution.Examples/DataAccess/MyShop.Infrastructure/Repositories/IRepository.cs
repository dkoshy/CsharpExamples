using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyShop.Infrastructure.Repositories;

public interface IRepository<T> where T : class
{
    T Add(T entity);
    T Update(T entity);
    void Delete(T entity);
    T Get(Guid? id);
    IReadOnlyList<T> All();
    IReadOnlyList<T> Find(Expression<Func<T, bool>> predicate);
    void SaveChanges();

}


public abstract class GenericRepository<T> : IRepository<T> where T : class
{
    public readonly ShoppingContext _shoppingContext;

    protected GenericRepository(ShoppingContext shoppingContext)
    {
        _shoppingContext = shoppingContext;
    }
    public virtual T Add(T entity)
    {
        return _shoppingContext.Set<T>().Add(entity).Entity;
    }

    public virtual IReadOnlyList<T> All()
    {
        var entities = _shoppingContext.Set<T>();
        return entities.ToList();
    }

    public virtual void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual IReadOnlyList<T> Find(Expression<Func<T, bool>> predicate)
    {
        var entities = _shoppingContext.Set<T>().Where(predicate);
        return entities.ToList();
    }

    public virtual T Get(Guid? id)
    {
      var item =  _shoppingContext.Set<T>()
            .Find(id);
        return item;
    }

    public virtual void SaveChanges()
    {
       _shoppingContext.SaveChanges();
    }

    public virtual T Update(T entity)
    {
        return _shoppingContext.Set<T>().Update(entity).Entity;
    }
}
