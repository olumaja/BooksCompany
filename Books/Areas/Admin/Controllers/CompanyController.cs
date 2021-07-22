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
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region

        [HttpGet]
        public IActionResult Get()
        {
            var companies = _companyRepository.GetAllCompanies();
            return Json(new { data = companies });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var company = _companyRepository.GetCompanyById(id);

            if(company == null)
            {
                return Json(new { sucess = false, message = "Error while deleting" });
            }

            _companyRepository.DeleteCompany(company);
            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion

        [HttpGet]
        public IActionResult Create()
        {
            var company = new Company();
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _companyRepository.AddCompany(company);
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var company = _companyRepository.GetCompanyById(id);

            if(company == null) { return NotFound(); }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Company company)
        {
            if (ModelState.IsValid)
            {
                _companyRepository.UpdateCompany(company);
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }
    }
}
