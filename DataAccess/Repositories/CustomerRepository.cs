using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly project1Context _context;
        public CustomerRepository(project1Context context)
        {
            _context = context;
        }
        public List<Library.Customer> GetAllCustomers()
        {
            var results = _context.Customers;

            List<Library.Customer> customers = new List<Library.Customer>();

            foreach (var result in results)
            {
                customers.Add(new Library.Customer(result.FirstName, result.LastName, result.Id));
            }

            return customers;
        }

        public Library.Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
