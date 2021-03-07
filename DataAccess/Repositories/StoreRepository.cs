using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class StoreRepository : IStoreLocationRepository 
    {
        private readonly project1Context _context;
        public StoreRepository(project1Context context)
        {
            _context = context;
        }
        public List<Library.StoreLocation> GetAllStores()
        {
            var results = _context.StoreLocations;

            List<Library.StoreLocation> storeLocations = new List<Library.StoreLocation>();

            foreach (var result in results)
            {
                storeLocations.Add(new Library.StoreLocation(result.City, result.State, result.Address, result.PhoneNumber, result.Id));
            }

            return storeLocations;
        }

        public Library.StoreLocation GetStoreById(int id)
        {
            var result = _context.StoreLocations.Where(x => x.Id == id).FirstOrDefault();

            Library.StoreLocation storeLocation = new Library.StoreLocation(result.City,result.State,result.Address,result.PhoneNumber,result.Id);

            return storeLocation;
        }

        public List<Library.OrderDetails> GetOrdersByCustomerId(int id)
        {
            List<Library.OrderDetails> orderDetails = new List<Library.OrderDetails>();
            
            var results = _context.Orders.Include(x => x.Customer).Include(x => x.StoreLocation).Include(x => x.OrderLines).ThenInclude(x => x.Product).Where(x => x.CustomerId == id);

            foreach (var result in results)
            {

                int numberOfProducts = 0;

                decimal totalPrice = 0;

                foreach(var orderline in result.OrderLines)
                {
                    numberOfProducts += orderline.Quantity;

                    totalPrice += orderline.Quantity * orderline.Product.Price.Value;
                }

                orderDetails.Add(new Library.OrderDetails { CustomerFirstName = result.Customer.FirstName,CustomerId=result.CustomerId,CustomerLastName=result.Customer.LastName,StoreCity=result.StoreLocation.City,StoreAddress=result.StoreLocation.Address,OrderId=result.Id,StoreState=result.StoreLocation.State,NumberOfProducts=numberOfProducts,TotalPrice=totalPrice});


            }

            return orderDetails;
        }

        public Library.Order GetOrderById(int id)
        {

            Library.Order order = new Library.Order();

            var result = _context.Orders.Include(x => x.Customer).Where(x => x.Id == id).FirstOrDefault();

            if(result != null)
            {
                order.OrderId = result.Id;

                order.CustomerFirstName = result.Customer.FirstName;

                order.CustomerLastName = result.Customer.LastName;

                order.OrderLines = this.GetOrderLinesByOrderId(result.Id);
            }

            return order;


        }

        public List<Library.OrderLine> GetOrderLinesByOrderId(int orderid)
        {

            List<Library.OrderLine> orderLines = new List<Library.OrderLine>();

            var results = _context.OrderLines.Where(x => x.OrderId == orderid).Include(x => x.Product);

            if(results != null)
            {
                foreach (var result in results)
                {
                    orderLines.Add(new Library.OrderLine()
                    {
                        OrderLineId = result.Id,
                        ProductId = result.ProductId,
                        ProductName = result.Product.ProductName,
                        Price = result.Product.Price.Value,
                        Quantity = result.Quantity

                    });
                };
            };

            return orderLines;


        }

    }
}
