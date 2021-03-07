using Cole_Project1.Models;
using DataAccess;
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

        private readonly IStoreLocationRepository _storeRepository;

        public CustomerController(ICustomerRepository customerrepository, IStoreLocationRepository storeLocationRepository)
        {
            this._storeRepository = storeLocationRepository;

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

        [HttpGet]
        [Route("GetOrders/{id}")]
        public IActionResult GetOrders(int id)
        {
            return Ok(_storeRepository.GetOrdersByCustomerId(id));
        }

        [HttpGet]
        [Route("GetOrderDetail/{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            return Ok(_storeRepository.GetOrderLinesByOrderId(id));
        }



    }
}
