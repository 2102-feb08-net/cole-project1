using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Library;

namespace Cole_Project1
{
    public static class RequestProcessor
    {
        /// <summary>
        /// Throws errors if a given request cant be fufilled. Otherwise fufills  it
        /// </summary>
        /// <param name="request"></param>
        /// <param name="repository"></param>
        public static void ProcessRequest(Library.Request request, IStoreLocationRepository repository)
        {
            Library.OrderDetails orderDetails = repository.GetOrderDetailsById(request.OrderId);

            Library.Product product = repository.GetProductByName(request.ProductName);

            int storequantity = repository.GetQuantityByProduct(product, orderDetails.StoreId);

            ValidateReasonableQuantity(request.Quantity);

            ValidateStoreCanSell(storequantity, request.Quantity);

            repository.CompleteTransaction(request, orderDetails.StoreId, product.Id);


        }

        public static void ValidateStoreCanSell(int storequantity,int requestquantity)
        {
            if(requestquantity > storequantity)
            {
                throw new ArgumentException("Store does not have enough quantity to fufill request");
            }
        }

        public static void ValidateReasonableQuantity(int requestquantity)
        {
            if (requestquantity > 1000)
            {
                throw new ArgumentException("Unreasonably high quantity ordered.");
            }
        }


    }
}
