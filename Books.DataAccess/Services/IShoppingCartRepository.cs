using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Services
{
    public interface IShoppingCartRepository
    {
        void AddShoppingCart(ShippingCart shoppingCart);
        IEnumerable<ShippingCart> GetAllShoppingCarts();
        ShippingCart GetShoppingCartById(int id);
        void UpdateShoppingCart(ShippingCart shoppingCart);
    }
}
