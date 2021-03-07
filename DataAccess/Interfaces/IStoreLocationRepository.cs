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

    }
}
