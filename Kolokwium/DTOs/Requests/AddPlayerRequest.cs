using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTOs.Requests
{
    public class AddPlayerRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime birthDate { get; set; }
        [Required]
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }
    }
}
