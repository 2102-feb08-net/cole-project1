using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cole_Project1.Models
{
    /// <summary>
    /// Used when posting a new customer to the server
    /// </summary>
    public class CustomerDTO
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get;set; }

        [Required]
        [StringLength(25)]
        public string LastName { get;  set; }

    }
}
