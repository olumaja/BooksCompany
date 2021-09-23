using Books.DataAccess.Data;
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
    [Authorize(Roles = HelpersClass.role_Admin + "," + HelpersClass.role_Emp)]
    public class UserController : Controller
    {
        private readonly IApplicationUserRepository _appUserRepo;
        private readonly IUserRolesRepository _userRoleRepo;
        private readonly IRolesRepository _roleRepo;

        public UserController(IApplicationUserRepository appUserRepo, IUserRolesRepository userRoleRepo, IRolesRepository roleRepo)
        {
            _appUserRepo = appUserRepo;
            _userRoleRepo = userRoleRepo;
            _roleRepo = roleRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API Calls
        
            [HttpGet]
            public IActionResult GetAll()
            {
                var users = _appUserRepo.GetAllUsers();
                var userRoles = _userRoleRepo.GetAllUserRoles();
                var roles = _roleRepo.GetAllRoles();

                foreach (var user in users)
                {
                    var roleId = userRoles.FirstOrDefault(s => s.UserId == user.Id).RoleId;
                    user.Role = roles.FirstOrDefault(r => r.Id == roleId).Name;

                    if(user.Company == null)
                    {
                        user.Company = new Company {Name = "Decagon" };
                    }

                }

                return Json(new { data = users });
            }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var user = _appUserRepo.GetAllUsers().FirstOrDefault(u => u.Id == id);

            if(user == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if(user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                //User is currently locked, then unlock user
                user.LockoutEnd = DateTime.Now;
            }
            else
            {
                //User is currently unlock, then lock user for 1000 years
                user.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _appUserRepo.UpdateUser(user);
            return Json(new { success = true, message = "Operation successful"});
        }

        #endregion

    }
}
