using Cole_Project1.Models;
using DataAccess;
using Dependencies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cole_Project1
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerRepository _customerRepository;

        public CustomerController()
        {
            using var disposables = new Disposables();

            var context = disposables.getContext();

            CustomerRepository customerrepository = new CustomerRepository(context);

            this._customerRepository = customerrepository;
        }

        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            return Ok(_customerRepository.GetAllCustomers().FirstOrDefault());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_customerRepository.GetCustomerById(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetSingle()
        {
            return Ok(_customerRepository.GetAllCustomers());
        }

        [HttpPost]
        public IActionResult CreateCustomer(Library.Customer customer)
        {
            return Ok(_customerRepository.CreateCustomer(customer));
        }

    }
}
