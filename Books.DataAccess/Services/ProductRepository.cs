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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Products.Include(p => p.Category).Include(c => c.CoverType);
        }

        public Product GetProductById(int id)
        {
            return _db.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void UpdateProduct(Product product)
        {
            //_db.Products.Update(product);
            var objFromDb = _db.Products.FirstOrDefault(s => s.ProductId == product.ProductId);
            if (objFromDb != null)
            {
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
                objFromDb.ISBN = product.ISBN;
                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price100 = product.Price100;
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.Author = product.Author;
                objFromDb.CoverTypeId = product.CoverTypeId;

            }
            _db.Products.Update(objFromDb);
            _db.SaveChanges();
        }
    }
}
