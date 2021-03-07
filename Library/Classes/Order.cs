using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public List<Library.OrderLine> OrderLines { get; set; }
    }
}
