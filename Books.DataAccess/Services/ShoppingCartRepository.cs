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
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddShoppingCart(ShippingCart shoppingCart)
        {
            _context.ShippingCarts.Add(shoppingCart);
            _context.SaveChanges();
        }

        public IEnumerable<ShippingCart> GetAllShoppingCarts()
        {
            return _context.ShippingCarts.Include(s => s.Product);
        }

        public ShippingCart GetShoppingCartById(int id)
        {
            return _context.ShippingCarts.FirstOrDefault(s => s.ShippingId == id);
        }

        public void UpdateShoppingCart(ShippingCart shoppingCart)
        {
            _context.ShippingCarts.Update(shoppingCart);
            _context.SaveChanges();
        }
    }
}
