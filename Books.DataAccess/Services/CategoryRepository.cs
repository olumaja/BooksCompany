using Books.DataAccess.Data;
using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCategory(Category model)
        {
             _context.Categories.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteCategory(Category model)
        {
            _context.Categories.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public bool UpdateCategory(Category model)
        {
            _context.Categories.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
