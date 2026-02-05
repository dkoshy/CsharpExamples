using MyShop.Domain.Models;

namespace MyShop.Infrastructure.Repositories;


public interface IOrderCreationUnitOfWorkRepo
{
     IRepository<Order> OrderRepository { get;}
     IRepository<Product> ProductRepository { get;}
     IRepository<Customer> CustomerRepository { get;}
    void SaveChanges();

}

public class OrderCreationUnitOfWorkRepo : IOrderCreationUnitOfWorkRepo
{
    private readonly ShoppingContext _shoppingContext;
    private IRepository<Order> _orderRepository;
    private IRepository<Product> _productRepository;
    private IRepository<Customer> _customerRepository;



    public OrderCreationUnitOfWorkRepo(ShoppingContext shoppingContext)
    {
        _shoppingContext = shoppingContext;
    }

    public IRepository<Order> OrderRepository
    {
        get 
        {
            _orderRepository = new OrderRepository(_shoppingContext);
            return _orderRepository;
        }
    }

    public IRepository<Product> ProductRepository
    {
        get
        {
            _productRepository = new ProductRepository(_shoppingContext);
            return _productRepository;
        }
    }

    public IRepository<Customer> CustomerRepository
    {
        get
        {
            _customerRepository = new CustomerRepository(_shoppingContext);
            return _customerRepository;
        }
    }

    public void SaveChanges()
    {
       _shoppingContext.SaveChanges();
    }
}
