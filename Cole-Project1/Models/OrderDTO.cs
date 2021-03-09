using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cole_Project1
{
    /// <summary>
    /// Used when adding a new order, ensures they use a positive int
    /// </summary>
    public class OrderDTO
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int CustomerId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int StoreId { get; set; }
    }
}
