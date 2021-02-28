using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
