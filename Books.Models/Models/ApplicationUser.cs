using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50, ErrorMessage ="Maximum character of 50")]
        public string Name { get; set; }
        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [MaxLength(15, ErrorMessage ="Maximum character of 15")]
        public string PostalCode { get; set; }
        [NotMapped]
        public string Role { get; set; }

        public Company Company { get; set; }
    }
}
