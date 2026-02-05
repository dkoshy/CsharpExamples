using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyShop.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order> 
{
    public OrderRepository(ShoppingContext shoppingContext)
        :base(shoppingContext)
    {
        
    }

    public override IReadOnlyList<Order> Find(Expression<Func<Order, bool>> predicate)
    {
       return _shoppingContext.Orders
             .Include(o => o.LineItems)
             .ThenInclude(o => o.Product)
             .Where(predicate)
             .ToList();
    }

    public override Order Update(Order entity)
    {
        var order =  _shoppingContext.Orders
                       .Include(o => o.LineItems)
                       .ThenInclude(o => o.Product)
                       .SingleOrDefault(o => o.OrderId == entity.OrderId);
        if(order != null)
        {
            order.OrderDate = entity.OrderDate;
            order.LineItems = entity.LineItems;
        }

       return base.Update(order);
    }

}
