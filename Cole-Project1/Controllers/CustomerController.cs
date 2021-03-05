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

        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerrepository)
        {
            this._customerRepository = customerrepository;
        }

        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            return Ok(_customerRepository.GetAll().FirstOrDefault());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_customerRepository.GetById(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetSingle()
        {
            return Ok(_customerRepository.GetAll());
        }
        
        [HttpGet("search/{firstName}/{lastName}")]

        public IActionResult SearchCustomers(string firstName, string lastName)
        {
            return Ok(_customerRepository.SearchCustomers(firstName, lastName));
        }


        [HttpPost("addnew")]
        public void CreateCustomer(CustomerDTO customer)
        {
            Library.Customer libcustomer = new Library.Customer(customer.FirstName, customer.LastName);

            _customerRepository.Create(libcustomer);
        }


    }
}
