using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
