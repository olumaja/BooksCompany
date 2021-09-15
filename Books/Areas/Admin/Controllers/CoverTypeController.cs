using Books.DataAccess.Services;
using Books.Model.Models;
using Books.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = HelpersClass.role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeRepository _coverTypeRepository;

        public CoverTypeController(ICoverTypeRepository coverTypeRepository)
        {
            _coverTypeRepository = coverTypeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region API Calls
        
            [HttpGet]
            public IActionResult GetAll()
            {
                var coverObj = _coverTypeRepository.GetAllCoverTypes();
                return Json(new { data = coverObj });
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var coverObj = _coverTypeRepository.GetCoverTypeById(id);
                
                if(coverObj == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                _coverTypeRepository.DeleteCoverType(coverObj);
                return Json(new { success = true, message = "Delete successful" });
            }

        #endregion

        [HttpGet]
        public IActionResult Create()
        {
            var coverObj = new CoverType(); 
            return View(coverObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverObj)
        {
            if (ModelState.IsValid)
            {
                _coverTypeRepository.AddCoverType(coverObj);
                return RedirectToAction(nameof(Index));
            }

            return View(coverObj);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var coverObj = _coverTypeRepository.GetCoverTypeById(id);

            if(coverObj == null) { return NotFound(); }

            return View(coverObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CoverType coverObj)
        {
            if (ModelState.IsValid)
            {
                _coverTypeRepository.UpdateCoverType(coverObj);
                return RedirectToAction(nameof(Index));
            }

            return View(coverObj);
        }

    }
}
