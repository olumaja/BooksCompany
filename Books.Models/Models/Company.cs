using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Maximum of 100 characters")]
        public string Name { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage ="Maximum of 11 characters")]
        public string PhoneNumber { get; set; }
        [Required]
        public bool IsAuthorizedCompany { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
