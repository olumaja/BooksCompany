using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class Roles
    {
        [NotMapped]
        public string Id { get; set; }
        [NotMapped]
        public string Name { get; set; }
    }
}
