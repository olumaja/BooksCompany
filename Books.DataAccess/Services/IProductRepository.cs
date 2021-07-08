using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product product);
    }
}
