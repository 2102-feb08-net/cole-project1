using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductRepository 
    {
        private readonly project1Context _context;
        public ProductRepository(project1Context context)
        {
            _context = context;
        }
        public List<Library.Prod> GetAllCustomers()
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
            var result = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

            Library.Customer customer = new Library.Customer(result.FirstName, result.LastName, result.Id);

            return customer;
        }

        public Library.Customer CreateCustomer(Library.Customer customer)
        {
            Customer sqlcustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            var newcustomer = _context.Add(sqlcustomer);

            Library.Customer returncustomer = new Library.Customer(newcustomer.Entity.FirstName, newcustomer.Entity.LastName, newcustomer.Entity.Id);

            return returncustomer;

        }
    }
}
