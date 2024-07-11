using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParaTech_Energy.Models
{
    public class FreeQuote
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Package { get; set; }
        public string Message { get; set; }
    }
}