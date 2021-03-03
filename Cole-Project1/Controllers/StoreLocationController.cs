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
    public class StoreLocationController : ControllerBase
    {

        private readonly StoreRepository _storeRepository;

        public StoreLocationController()
        {
            using var disposables = new Disposables();

            var context = disposables.getContext();

            StoreRepository storerepository = new StoreRepository(context);

            this._storeRepository = storerepository;
        }


        [HttpGet("storelocation/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_storeRepository.GetStoreById(id));
        }

        [HttpGet]
        [Route("storelocations")]
        public IActionResult GetSingle()
        {
            return Ok(_storeRepository.GetAllStores());


        }
    }
}