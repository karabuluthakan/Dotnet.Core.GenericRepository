using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dotnet.Core.Common.Entities;

namespace Dotnet.Core.Common.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null);
        T GetFindById(object id);
        T Get(Expression<Func<T, bool>> filter = null);
        IQueryable<T> Table { get; }
        IQueryable<T> GetListPaging(Expression<Func<T, bool>> filter, out int total, int index, int size);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        int Count();

        Task<T> GetFindByIdAsync(object id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        void AddRange(IEnumerable<T> listEntity);
        void UpdateAll(Expression<Func<T, bool>> filter = null);
        void Delete(Expression<Func<T, bool>> filter);
        void DeleteAll(Expression<Func<T, bool>> filter = null);
        
        void Dispose();
    }
}