using Books.DataAccess.Data;
using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public class RolesRepository : IRolesRepository
    {
        private readonly ApplicationDbContext _context;

        public RolesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            List<Roles> roles = new List<Roles>();
            var roleList = _context.Roles.ToList();

            foreach (var role in roleList)
            {
                var roleObj = new Roles { Id = role.Id, Name = role.Name };
                roles.Add(roleObj);
            }

            return roles;
        }
    }
}
