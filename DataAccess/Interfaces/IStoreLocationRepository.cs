using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IStoreLocationRepository
    {
        public List<Library.StoreLocation> GetAllStores();

        public Library.StoreLocation GetStoreById(int id);

        public List<Library.OrderDetails> GetOrdersByCustomerId(int id);

        public List<Library.OrderLine> GetOrderLinesByOrderId(int orderid);

        public Library.OrderDetails GetOrderDetailsById(int id);

        public List<Library.Product> GetStoreProductsByOrderId(int id);

        public Library.Product GetProductByName(string name);

        public int GetQuantityByProduct(Library.Product product, int orderid);

        public void CompleteTransaction(Library.Request request, int storeid, int productid);

    }
}
