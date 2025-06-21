using DPN.DataAccess.Data;
using DPN.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DPN.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string properties = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter); //select * from table where
            }
            if(properties != null)
            {
                foreach (var property in properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            if(orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> filter = null, string properties = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter); //select * from table where
            }
            if (properties != null)
            {
                foreach (var property in properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
