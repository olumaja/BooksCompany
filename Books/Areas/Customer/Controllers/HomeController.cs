using Books.DataAccess.Services;
using Books.Model;
using Books.Model.Models;
using Books.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Books.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCart;

        public HomeController(
                ILogger<HomeController> logger, IProductRepository productRepository, IShoppingCartRepository shoppingCart
            )
        {
            _logger = logger;
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _productRepository.GetAllProducts().ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetAllProducts().FirstOrDefault(p => p.ProductId == id);
            ShippingCart cart = new ShippingCart
            {
                Product = product,
                ProductId = product.ProductId
            };

            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShippingCart cart)
        {
            cart.ShippingId = 0;

            if (ModelState.IsValid)
            {
                ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                cart.ApplicationUserId = claim.Value;
                ShippingCart cartFromDb = _shoppingCart.GetAllShoppingCarts().FirstOrDefault(c => c.ApplicationUserId == cart.ApplicationUserId && c.ProductId == cart.ProductId);

                if(cartFromDb == null)
                {
                    _shoppingCart.AddShoppingCart(cart);
                }
                else
                {
                    cartFromDb.Count += cart.Count;
                    _shoppingCart.UpdateShoppingCart(cartFromDb);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var product = _productRepository.GetAllProducts().FirstOrDefault(p => p.ProductId == cart.ShippingId);
                ShippingCart shippingCart = new ShippingCart
                {
                    Product = product,
                    ProductId = product.ProductId
                };
                return View(cart);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
