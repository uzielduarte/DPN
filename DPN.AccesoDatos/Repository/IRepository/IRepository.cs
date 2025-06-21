using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DPN.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string properties = null,
            bool isTracking = true);

        Task<T> GetFirst(
            Expression<Func<T, bool>> filter = null,
            string properties = null,
            bool isTracking = true);

        Task Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

    }
}
