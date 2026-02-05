using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer>  customerRepository )
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = _customerRepository.All();

                return View(customers);
            }
            else
            {
                var customer = _customerRepository.Get(id);

                return View(new[] { customer });
            }
        }
    }
}
