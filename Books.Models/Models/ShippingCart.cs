using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class ShippingCart
    {

        public ShippingCart()
        {
            Count = 1;
        }

        [Key]
        public int ShippingId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Range(1, 1000, ErrorMessage ="Please enter a value between 1 and 1000")]
        public int Count { get; set; }
        [NotMapped]
        public double Price { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Product Product { get; set; }
    }
}
