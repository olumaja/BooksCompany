using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(string id);
        void AddUser(ApplicationUser user);
        void UpdateUser(ApplicationUser user);
        void DeleteUser(ApplicationUser user);
    }
}
