using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dotnet.Core.Common.Contracts;
using Dotnet.Core.Common.Entities; 

namespace Dotnet.Core.Common.Business
{
    public interface IEntityService<T> where T : class, IEntity, new() 
    {
        Result<T> GetFindById(object id);
        Result<T> Get(Expression<Func<T, bool>> filter = null);
        Result<IEnumerable<T>> GetList(Expression<Func<T, bool>> filter = null);

        Result<IEnumerable<T>> GetListPaging(Expression<Func<T, bool>> filter, out int total,
            int index = 0,
            int size = 15);

        Result<T> Add(T entity);
        Result<bool> AddRange(IEnumerable<T> listEntity);
        Result<T> Update(T entity);
        Result<bool> Delete(T entity);
        bool Delete(Expression<Func<T, bool>> filter);
        bool DeleteAll(Expression<Func<T, bool>> filter = null);

        Task<T> GetFindByIdAsync(object id);
        Task<Result<T>> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<bool>> DeleteAsync(T entity);
        void Dispose();
    }
}