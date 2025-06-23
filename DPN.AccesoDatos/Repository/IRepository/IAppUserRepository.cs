using DPN.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DPN.DataAccess.Repository.IRepository
{
    public interface IAppUserRepository
    {
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<AppUser> FindByIdAsync(string id);
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task<IdentityResult> UpdateUserAsync(AppUser user);
        Task<IdentityResult> DeleteUserAsync(AppUser user);

        Task<AppUser> GetFirstAsync(Expression<Func<AppUser, bool>> filter);

        Task<IList<string>> GetRolesAsync(AppUser user);

        Task<bool> AddToRoleAsync(AppUser user, string roleName);

        Task<bool> RemoveFromRoleAsync(AppUser user, string roleName);
    }
}
