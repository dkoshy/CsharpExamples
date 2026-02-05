using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>
{
    public CustomerRepository( ShoppingContext shoppingContext) 
        : base(shoppingContext)
    {
        
    }
    public override IReadOnlyList<Customer> All()
    {
        //return base.All()
        //            .Select(c =>
        //            {
        //                c.ProfilePictureValueHolder = new Lazy<byte[]>(() => ProfilePictureService.GetFor(c.Name));
        //                return c;
        //            }).ToList();

        return base.All()
                     .Select(c => new CustomerProxy
                     {
                         CustomerId = c.CustomerId,
                         Name = c.Name,
                         ShippingAddress = c.ShippingAddress,
                         City = c.City,
                         PostalCode = c.PostalCode,
                         Country = c.Country
                     }).ToList();

        //return base.All().Select(c =>
        //{
        //    c.ProfilePictureValueHolder = new ValueHolder<byte[]>(p =>
        //    {

        //        return ProfilePictureService.GetFor(p.ToString());

        //    });
        //    return c;
        //}).ToList();


    }

    public override Customer Get(Guid? id)
    {
        var customer = base.Get(id);

        //customer.ProfilePictureValueHolder = new Lazy<byte[]>(() =>
        //{
        //    return ProfilePictureService.GetFor(customer.Name);
        //});

        //customer.ProfilePictureValueHolder = new ValueHolder<byte[]>(p =>
        //{
        //    return ProfilePictureService.GetFor(p.ToString());
        //});
        customer = new CustomerProxy
        {
            CustomerId = customer.CustomerId,
            Name = customer.Name,
            ShippingAddress = customer.ShippingAddress,
            City = customer.City,
            PostalCode = customer.PostalCode,
            Country = customer.Country
        };
        return customer;
    }
    

    public override Customer Update(Customer entity)
    {
        var cutsomer = _shoppingContext.Customers
                           .SingleOrDefault(c =>  c.CustomerId ==  entity.CustomerId);

        if(cutsomer!=null)
        {
           cutsomer.Name = entity.Name;
           cutsomer.ShippingAddress = entity.ShippingAddress;
           cutsomer.City = entity.City;
           cutsomer.PostalCode = entity.PostalCode;
           cutsomer.Country = entity.Country;
        }
        return base.Update(cutsomer);
    }
}
