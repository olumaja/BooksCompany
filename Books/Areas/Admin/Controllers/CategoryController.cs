using Books.DataAccess.Services;
using Books.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API Calls
            
            [HttpGet]
            public IActionResult GetAll()
            {
                var categoryObj = _categoryRepository.GetAllCategories();
                return Json(new { data = categoryObj });
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var category = _categoryRepository.GetCategoryById(id);

                if(category == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                _categoryRepository.DeleteCategory(category);
                return Json(new { success = true, message = "Delete successful" });
            }

        #endregion

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Category();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _categoryRepository.GetCategoryById(id);
            if (model == null) { return NotFound(); }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category model)
        {

            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
