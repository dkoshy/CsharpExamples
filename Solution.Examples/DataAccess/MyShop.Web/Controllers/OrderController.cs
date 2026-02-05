using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Models;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderCreationUnitOfWorkRepo _repository;

        //private readonly IRepository<Order> _orderRepository;
        //private readonly IRepository<Product> _productRepository;
        //private readonly IRepository<Customer> _customerRepository;

        public OrderController(IOrderCreationUnitOfWorkRepo repository)
        {
             _repository = repository;
            //_orderRepository = orderRepository;
            //_productRepository = productRepository;
            //_customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var orderRepo = _repository.OrderRepository;
            var orders = orderRepo.Find(o => o.OrderDate > DateTime.UtcNow.AddDays(-1));
            return View(orders);
        }

        public IActionResult Create()
        {
            var productRepo = _repository.ProductRepository;
            var products = productRepo.All();
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var orderRepo = _repository.OrderRepository;
            var customerRepo = _repository.CustomerRepository;

            var customer = customerRepo
                  .Find(c => c.Name ==  model.Customer.Name)
                  .FirstOrDefault();
            if(customer != null)
            {
                customer.Name = model.Customer.Name;
                customer.ShippingAddress = model.Customer.ShippingAddress;
                customer.PostalCode = model.Customer.PostalCode;
                customer.City = model.Customer.City;
                customer.Country = model.Customer.Country;

                customerRepo.Update(customer);
            }
            else
            {
                 customer = new Customer
                {
                    Name = model.Customer.Name,
                    ShippingAddress = model.Customer.ShippingAddress,
                    City = model.Customer.City,
                    PostalCode = model.Customer.PostalCode,
                    Country = model.Customer.Country
                };
                customerRepo.Add(customer);
            }
         
            var order = new Order
            {
                LineItems = model.LineItems
                    .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
                    .ToList(),

                Customer = customer
            };
            orderRepo.Add(order);
            _repository.SaveChanges();
            return Ok("Order Created");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
