
using DPN.DataAccess.Data;
using DPN.DataAccess.Repository;
using DPN.DataAccess.Repository.IRepository;
using DPN.Models;
using DPN.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ApplicationDbContext _db;

        public UserController(IAppUserRepository appUserRepository, IRoleRepository roleRepository, ApplicationDbContext db)
        {
            _appUserRepository = appUserRepository;
            _roleRepository = roleRepository;
            _db = db;
        }
        public IActionResult Index()
        {
            
            //var isAdmin = User.IsInRole("Admin");

            return View();
        }

        #region API

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userList = await _appUserRepository.GetAllAsync();

            var userRole = await _db.UserRoles.ToListAsync();

            var roles = await _db.Roles.ToListAsync();

            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(r => r.Id == roleId).Name;   
            }

            return Json(new { data = userList });
        }

        [HttpPost]
        public async Task<IActionResult> LockUnlock([FromBody] string id)
        {
            //var user = await _unitOfWork.AppUser.GetFirst(u => u.Id == id);
            var user = await _appUserRepository.GetFirstAsync(u => u.Id == id);


            if (user == null)
            {
                return Json(new { success = false, message = "Error de usuario" });
            }
            if(user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now;
            }
            else
            {
                user.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            //await _unitOfWork.Save();
            await _appUserRepository.UpdateUserAsync(user);

            return Json(new { success = true, message = "Operacion Exitosa" });
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id){}
        #endregion
    }
}
