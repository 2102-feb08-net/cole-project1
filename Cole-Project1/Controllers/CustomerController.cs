using Cole_Project1.Models;
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

        private readonly CustomerRepository _customerService;

        public CustomerController(CustomerRepository customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetSingle()
        {
            return Ok();
        }
    }
}
