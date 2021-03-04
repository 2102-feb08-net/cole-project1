using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class CustomerDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<OrderDetails> OrderDertails { get; set; }

    }
}
