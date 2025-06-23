
using DPN.DataAccess.Data;
using DPN.DataAccess.Repository;
using DPN.DataAccess.Repository.IRepository;
using DPN.Models;
using DPN.Models.ViewModels;
using DPN.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin)]
    [Route("Admin/User")]
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

        [HttpGet("Index")]
        public IActionResult Index()
        {
            
            //var isAdmin = User.IsInRole("Admin");

            return View();
        }

        #region API

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var userList = await _appUserRepository.GetAllAsync();

            var userRole = await _db.UserRoles.ToListAsync();

            // var roles = await _db.Roles.ToListAsync();
            var roles = await _roleRepository.GetAllAsync();

            foreach (var user in userList)
            {
                //var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                //user.Role = roles.FirstOrDefault(r => r.Id == roleId).Name;   
                var userRoleEntry = userRole.FirstOrDefault(u => u.UserId == user.Id);
                if (userRoleEntry != null)
                {
                    var role = roles.FirstOrDefault(r => r.Id == userRoleEntry.RoleId);
                    if (role != null)
                    {
                        user.Role = role.Name;
                    }
                }
            }

            return Json(new { data = userList });
        }

        [HttpPost("LockUnlock")]
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

            
            await _appUserRepository.UpdateUserAsync(user);

            return Json(new { success = true, message = "Operacion Exitosa" });
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            var user = await _appUserRepository.FindByIdAsync(id);
            
            if(user == null)
            {
                return Json(new { success = false, message = "Usuario no encontrado" });
            }
            if (user.isSystemUser)
            {
                return Json(new { success = false, message = "No se puede eliminar este usuario del sistema." });
            }
                
            await _appUserRepository.DeleteUserAsync(user);
            return Json(new { success = true, message = "Usuario eliminado exitosamente" });
        }



        [HttpGet("Roles/{id}")]
        public async Task<IActionResult> Roles(string id)
        {
            Console.WriteLine("Metodo Roles " + id);
            var user = await _appUserRepository.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userRoles = await _appUserRepository.GetRolesAsync(user);
            var allRoles = await _roleRepository.GetAllListAsync();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = userRoles,
                AllRoles = allRoles
            };

            return View(viewModel);
        }

        [HttpPost("Roles/Add")]
        public async Task<IActionResult> AddRole(string userId, string roleName)
        {
            var user = await _appUserRepository.FindByIdAsync(userId);
            if (user == null || !await _roleRepository.RoleExistsAsync(roleName))
                return BadRequest();

            await _appUserRepository.AddToRoleAsync(user, roleName);
            
            return RedirectToAction("Roles", new { id = userId });
        }

        [HttpPost("Roles/Remove")]
        public async Task<IActionResult> RemoveRole(string userId, string roleName)
        {
            var user = await _appUserRepository.FindByIdAsync(userId);
            if (user == null || !await _roleRepository.RoleExistsAsync(roleName))
                return BadRequest();

            await _appUserRepository.RemoveFromRoleAsync(user, roleName);
            return RedirectToAction("Roles", new { id = userId });
        }

        #endregion
    }
}
