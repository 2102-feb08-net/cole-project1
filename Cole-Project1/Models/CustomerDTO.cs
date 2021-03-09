using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cole_Project1.Models
{
    public class CustomerDTO
    {
        [Required]
        [StringLength(10)]
        public string FirstName { get;set; }

        [Required]
        [StringLength(10)]
        public string LastName { get;  set; }

    }
}
