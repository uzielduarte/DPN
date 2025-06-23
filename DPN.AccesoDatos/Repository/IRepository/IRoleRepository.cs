using DPN.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPN.DataAccess.Repository.IRepository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<AppRole>> GetAllAsync();
        Task<AppRole?> FindByIdAsync(string id);
        Task<AppRole?> FindByNameAsync(string name);
        Task<IdentityResult> CreateAsync(AppRole role);
        Task<IdentityResult> UpdateAsync(AppRole role);
        Task<IdentityResult> DeleteAsync(AppRole role);
    }
}
