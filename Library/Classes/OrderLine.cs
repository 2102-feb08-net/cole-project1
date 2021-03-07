using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
