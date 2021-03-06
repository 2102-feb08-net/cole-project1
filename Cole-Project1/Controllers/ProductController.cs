﻿using Cole_Project1.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Cole_Project1
{
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Returns a product for a given product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("product/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_productRepository.GetById(id));
        }
        /// <summary>
        /// Returns a list of all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("products")]
        public IEnumerable<Library.Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

    }
}