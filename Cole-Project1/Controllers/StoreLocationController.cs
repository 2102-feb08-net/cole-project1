using Cole_Project1.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library;

namespace Cole_Project1
{

    [ApiController]
    public class StoreLocationController : ControllerBase
    {

        private readonly IStoreLocationRepository _storeRepository;

        public StoreLocationController(IStoreLocationRepository storeLocationRepository)
        {
            _storeRepository = storeLocationRepository;
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

        
        [HttpGet("storeinventory/{id}")]
        public IActionResult GetInventory(int id)
        {
            return Ok(_storeRepository.GetStoreProductsByOrderId(id));


        }

        [HttpPost("processrequest")]
        public IActionResult ProcessRequest(Library.Request request)
        {

            return (Ok(request)); 

        }
    }
}