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
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductRepository _productRepository;

        public ProductController()
        {
            using var disposables = new Disposables();

            var context = disposables.getContext();

            ProductRepository productrepo = new ProductRepository(context);

            this._productRepository = productrepo;
        }


        [HttpGet("product/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_productRepository.GetProductById(id));
        }

        [HttpGet("products")]
        public IEnumerable<Library.Product> GetAll()
        {
            return _productRepository.GetAllProducts().ToList();
        }

    }
}