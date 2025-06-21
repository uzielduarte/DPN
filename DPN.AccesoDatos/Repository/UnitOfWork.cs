using DPN.DataAccess.Data;
using DPN.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPN.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
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
