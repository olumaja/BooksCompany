using Books.DataAccess.Data;
using Books.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRolesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRole> GetAllUserRoles()
        {
            List<UserRole> userRoles = new List<UserRole>();
            var userRoleList = _context.UserRoles.ToList();

            foreach(var role in userRoleList)
            {
                var userRole = new UserRole { RoleId = role.RoleId, UserId = role.UserId };
                userRoles.Add(userRole);
            }

            return userRoles;
        }
    }
}
