using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
        public DateTime? TimeCreated { get; set; }
        public int CustomerId { get; set; }
        public int StoreLocationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreLocation StoreLocation { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
