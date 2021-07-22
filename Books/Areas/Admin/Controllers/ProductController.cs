using Books.DataAccess.Services;
using Books.Model.Models;
using Books.Model.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _product;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ICategoryRepository _category;
        private readonly ICoverTypeRepository _coverType;

        public ProductController(
                IProductRepository product, IWebHostEnvironment hostEnvironment, ICategoryRepository category, ICoverTypeRepository coverType
            )
        {
            _product = product;
            _hostEnvironment = hostEnvironment;
            _category = category;
            _coverType = coverType;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALL

            [HttpGet]
            public IActionResult GetAll()
            {
                var product = _product.GetAllProducts();
                return Json(new { data = product });
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var product = _product.GetProductById(id);
                
                if(product == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                var webRootPath = _hostEnvironment.WebRootPath;
                var imgPath = Path.Combine(webRootPath, product.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
                _product.DeleteProduct(product);
                return Json(new { success = true, message = "Delete Successful" });
            }

        #endregion

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductViewModel
            {
                Product = new Product(),
                CategoryList = _category.GetAllCategories().Select(c => new SelectListItem {
                    Text = c.Name,
                    Value = c.CategoryId.ToString()
                }),
                CoverTypeList = _coverType.GetAllCoverTypes().Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.CoverTypeId.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel productView)
        {
            if (ModelState.IsValid)
            {

                var webRootPath = _hostEnvironment.WebRootPath;
                //To get all the files that were uploaded
                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    //File name for the images
                    var fileName = Guid.NewGuid().ToString();
                    //Web root path (wwwroot)
                    var uploadPath = Path.Combine(webRootPath, @"images\products");
                    var fileExtension = Path.GetExtension(files[0].FileName);

                    //Upload new image into the products folder
                    using (var filesStreams = new FileStream(Path.Combine(uploadPath, fileName + fileExtension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    //update the image inside the database
                    productView.Product.ImageUrl = @"\images\products\" + fileName + fileExtension;
                    _product.AddProduct(productView.Product);
                    return RedirectToAction(nameof(Index));
                }
                
                return View(productView);

            }
            else
            {
                productView.CategoryList = _category.GetAllCategories().Select(c => new SelectListItem { 
                    Text = c.Name,
                    Value = c.CategoryId.ToString()
                });
                productView.CoverTypeList = _coverType.GetAllCoverTypes().Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.CoverTypeId.ToString()
                });
            }

            return View(productView);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var productVM = new ProductViewModel
            {
                Product = _product.GetProductById(id),
                CategoryList = _category.GetAllCategories().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.CategoryId.ToString()
                }),
                CoverTypeList = _coverType.GetAllCoverTypes().Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.CoverTypeId.ToString()
                })
            };

            if(productVM.Product == null) { return NotFound(); }

            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductViewModel productView)
        {
            if (ModelState.IsValid)
            {
                var webRootPath = _hostEnvironment.WebRootPath;
                //To get all the files that were uploaded
                var files = HttpContext.Request.Form.Files;

                if(files.Count > 0)
                {
                    //File name for the images
                    var fileName = Guid.NewGuid().ToString();
                    //Web root path (wwwroot)
                    var uploadPath = Path.Combine(webRootPath, @"images\products");
                    var fileExtension = Path.GetExtension(files[0].FileName);

                    if(productView.Product.ImageUrl != null)
                    {
                        //This is an edit action
                        //If the uploaded image already exist in the products folder delete it
                        var imagePath = Path.Combine(webRootPath, productView.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    //Upload new image into the products folder
                    using (var filesStreams = new FileStream(Path.Combine(uploadPath, fileName + fileExtension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    //update the image
                    productView.Product.ImageUrl = @"\images\products\" + fileName + fileExtension;
                }
                else
                {
                    //update when they do not change the image
                    if (productView.Product.ProductId != 0)
                    {
                        Product objFromDb = _product.GetProductById(productView.Product.ProductId);
                        productView.Product.ImageUrl = objFromDb.ImageUrl;
                    }
                }

                _product.UpdateProduct(productView.Product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                productView.CategoryList = _category.GetAllCategories().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.CategoryId.ToString()
                });
                productView.CoverTypeList = _coverType.GetAllCoverTypes().Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.CoverTypeId.ToString()
                });

                if(productView.Product.ProductId != 0)
                {
                    productView.Product = _product.GetProductById(productView.Product.ProductId);
                }
            }

            return View(productView);
        }
    }
}
