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

        private static Customer customer = new Customer() { FirstName ="Todd",LastName="Boggins",Id=1};

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customer);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetSingle()
        {
            return Ok(customer);
        }
    }
}
