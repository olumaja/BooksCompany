using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public interface IRolesRepository
    {
        IEnumerable<Roles> GetAllRoles();
    }
}
