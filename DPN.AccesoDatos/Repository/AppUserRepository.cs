using DPN.DataAccess.Data;
using DPN.DataAccess.Repository.IRepository;
using DPN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DPN.DataAccess.Repository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<AppUser> FindByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            // UserManager no tiene un método GetAll directo,
            // pero puedes acceder al IQueryable de usuarios si lo necesitas.
            return await Task.FromResult(_userManager.Users.ToList());
        }

        public async Task<IdentityResult> UpdateUserAsync(AppUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(AppUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<AppUser> GetFirstAsync(Expression<Func<AppUser, bool>> filter)
        {
            return await _userManager.Users.FirstOrDefaultAsync(filter);
        }

    }
}
