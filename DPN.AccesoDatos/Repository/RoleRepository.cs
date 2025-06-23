using DPN.DataAccess.Repository.IRepository;
using DPN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class RoleRepository : IRoleRepository
{
    private readonly RoleManager<AppRole> _roleManager;

    public RoleRepository(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<IEnumerable<AppRole>> GetAllAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task<AppRole?> FindByIdAsync(string id)
    {
        return await _roleManager.FindByIdAsync(id);
    }

    public async Task<AppRole?> FindByNameAsync(string name)
    {
        return await _roleManager.FindByNameAsync(name);
    }

    public async Task<IdentityResult> CreateAsync(AppRole role)
    {
        return await _roleManager.CreateAsync(role);
    }

    public async Task<IdentityResult> UpdateAsync(AppRole role)
    {
        return await _roleManager.UpdateAsync(role);
    }

    public async Task<IdentityResult> DeleteAsync(AppRole role)
    {
        return await _roleManager.DeleteAsync(role);
    }
}
