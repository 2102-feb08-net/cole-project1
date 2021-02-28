using Cole_Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cole_Project1
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);



    }
}
