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
        /// <summary>
        /// Returns all customers in database.
        /// </summary>
        /// <returns></returns>
        public List<Library.Customer> GetAll()
        {
            var results = _context.Customers;

            List<Library.Customer> customers = new List<Library.Customer>();

            foreach (var result in results)
            {
                customers.Add(new Library.Customer(result.FirstName, result.LastName, result.Id));
            }

            return customers;
        }
        /// <summary>
        /// Returns customer given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Library.Customer GetById(int id)
        {
            var result = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

            Library.Customer customer = new Library.Customer(result.FirstName, result.LastName, result.Id);

            return customer;
        }
        /// <summary>
        /// Creates new customer
        /// </summary>
        /// <param name="customer"></param>
        public void Create(Library.Customer customer)
        {
            Customer sqlcustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            _context.Add(sqlcustomer);

            _context.SaveChanges();


        }
        /// <summary>
        /// Searches for a customer given a first and last name
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>

        public List<Library.Customer> SearchCustomers(string firstname, string lastname)
        {
            ///Quick check if a search is null or whitespace, if it is, it sets the string to xxx to avoid recieving all entries back.

            if (string.IsNullOrWhiteSpace(firstname))
            {
                firstname = "xxx";
            }
            if (string.IsNullOrWhiteSpace(lastname))
            {
                lastname = "xxx";
            }

            List<Library.Customer> customers = new List<Library.Customer>();

            var results = _context.Customers.Where(x => x.FirstName.Contains(firstname) && x.LastName.Contains(lastname));

            foreach (var result in results)
            {
                customers.Add(new Library.Customer(result.FirstName, result.LastName, result.Id));
            }

            return customers;
        }


    }


}
