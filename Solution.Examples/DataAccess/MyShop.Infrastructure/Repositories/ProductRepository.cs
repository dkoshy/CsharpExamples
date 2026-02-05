using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>
{
    public ProductRepository(ShoppingContext shoppingContext) 
        : base(shoppingContext)
    {


    }

    public override Product Update(Product entity)
    {
        var product = _shoppingContext.Products
                           .SingleOrDefault(p => p.ProductId == entity.ProductId);
        if(product != null)
        {
            product.Name = entity.Name;
            product.Price = entity.Price;
        }
     
        return base.Update(product);
    }
}
