using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface ICustomerRepository
    {

        public List<Library.Customer> SearchCustomers(string firstname, string lastname);

        public void Create(Library.Customer customer);

        public Library.Customer GetById(int id);

        public List<Library.Customer> GetAll();


    }
}
