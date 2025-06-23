using DPN.DataAccess.Repository.IRepository;
using DPN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace DPN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Upsert")]
        public async Task<IActionResult> Upsert(string? id)
        {
            AppRole role = new AppRole();
            
            if(id.IsNullOrEmpty())
            {
                role.Id = "";
                return View(role);
            }

            role = await _roleRepository.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost("Upsert")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AppRole rol)
        {
            
            if (ModelState.IsValid)
            {
                if (rol.Id.IsNullOrEmpty())
                {
                    await _roleRepository.CreateAsync(rol);
                }
                else
                {
                    var rolFromDb = await _roleRepository.FindByIdAsync(rol.Id);

                    if (rolFromDb == null)
                    {
                        await _roleRepository.CreateAsync(rol);
                        return RedirectToAction(nameof(Index));
                    }

                    rolFromDb.Name = rol.Name;
                    rolFromDb.RoleDescription = rol.RoleDescription;

                    await _roleRepository.UpdateAsync(rolFromDb);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(rol);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody]string id)
        {
            //string id = data?.id;
            //Console.WriteLine($"Intentando borrar el rol con ID: {id}");

            var appRole = await _roleRepository.FindByIdAsync(id);

            if (appRole == null)
            {
                return Json(new { success = false, message = "Rol no encontrado" });
            }

            await _roleRepository.DeleteAsync(appRole);
            return Json(new { success = true, message = "Rol borrado exitosamente" });
        }

        #region API

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleRepository.GetAllAsync();

            return Json(new { data = roles });
        }
        #endregion
    }
}
