using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICustomerRepository
    {
        List<Library.Customer> GetAllCustomers();
        Library.Customer GetCustomerById(int id);



    }
}
