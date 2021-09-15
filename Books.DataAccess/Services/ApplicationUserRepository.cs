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
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(ApplicationUser user)
        {
            _context.ApplicationUsers.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(ApplicationUser user)
        {
            _context.ApplicationUsers.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.ApplicationUsers.Include(a => a.Company).ToList();
        }

        public ApplicationUser GetUserById(string id)
        {
            return _context.ApplicationUsers.FirstOrDefault(a => a.Id == id);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _context.ApplicationUsers.Update(user);
            _context.SaveChanges();
        }
    }
}
