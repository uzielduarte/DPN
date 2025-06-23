using DPN.DataAccess.Data;
using DPN.DataAccess.Repository.IRepository;
using DPN.Models;
using Microsoft.AspNetCore.Identity;

namespace DPN.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IAppUserRepository AppUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
           // AppUser = new AppUserRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
