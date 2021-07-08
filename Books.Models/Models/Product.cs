using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [ForeignKey("CoverTypeId")]
        public int CoverTypeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters")]
        public string Author { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public Category Category { get; set; }
        public CoverType CoverType { get; set; }
    }
}
