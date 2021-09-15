using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class UserRole
    {
        [NotMapped]
        public string UserId { get; set; }
        [NotMapped]
        public string RoleId { get; set; }
    }
}
