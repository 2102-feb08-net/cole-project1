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
        /// <summary>
        /// Gets details of a store by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("storelocation/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_storeRepository.GetStoreById(id));
        }
        /// <summary>
        /// Gets a list of all store locations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("storelocations")]
        public IActionResult GetSingle()
        {
            return Ok(_storeRepository.GetAllStores());


        }
        /// <summary>
        /// Gets the store inventory a given order, because if your order is for a certain store location, youll only want to be able to select those options.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("storeinventory/{id}")]
        public IActionResult GetInventory(int id)
        {
            return Ok(_storeRepository.GetStoreProductsByOrderId(id));


        }
        /// <summary>
        /// Posts a request which is essentially one order, a product, quantity, and orderid to be placed on.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("processrequest")]
        public void AddProduct(Library.Request request)
        {
            RequestProcessor.ProcessRequest(request, _storeRepository);
        }

        /// <summary>
        /// Gets orders for a given store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("storelocation/GetOrders/{id}")]
        public IActionResult GetOrders(int id)
        { 
                return Ok(_storeRepository.GetOrdersByStoreId(id));
        }
        /// <summary>
        /// Adds an order to the database
        /// </summary>
        /// <param name="order"></param>

        [HttpPost("addorder")]
        public void AddOrder(OrderDTO order)
        {
            _storeRepository.AddOrder(order.CustomerId, order.StoreId);
        }
    }
}