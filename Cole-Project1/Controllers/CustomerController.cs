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

        /// <summary>
        /// Returns a customer with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_customerRepository.GetById(id));
        }

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_customerRepository.GetAll());
        }
        
        /// <summary>
        /// Returns a customer if the first/last name match the customer.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpGet("search/{firstName}/{lastName}")]

        public IActionResult SearchCustomers(string firstName, string lastName)
        {
            return Ok(_customerRepository.SearchCustomers(firstName, lastName));
        }

        /// <summary>
        /// Adds customer to sql database
        /// </summary>
        /// <param name="customer"></param>
        [HttpPost("addnew")]
        public void CreateCustomer(CustomerDTO customer)
        {
            Library.Customer libcustomer = new Library.Customer(customer.FirstName, customer.LastName);

            _customerRepository.Create(libcustomer);
        }
        /// <summary>
        /// Gets orders for a certain customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrders/{id}")]
        public IActionResult GetOrders(int id)
        {
            return Ok(_storeRepository.GetOrdersByCustomerId(id));
        }
        /// <summary>
        /// Gets order lines for a specific customers order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrderDetail/{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            return Ok(_storeRepository.GetOrderLinesByOrderId(id));
        }
        /// <summary>
        /// Gets order details by order id, probably belongs in order controller but it's just one function so who cares.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            return Ok(_storeRepository.GetOrderDetailsById(id));
        }




    }
}
