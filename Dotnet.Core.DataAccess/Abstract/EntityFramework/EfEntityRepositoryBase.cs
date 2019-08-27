using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using System.Threading.Tasks;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.Common.Entities;
using Dotnet.Core.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Core.DataAccess.Abstract.EntityFramework
{
    public abstract class EfEntityRepositoryBase<T> : IEntityRepository<T>
        where T : class, IEntity, new()
    {
        protected readonly GenericContext _context;
        private readonly DbSet<T> _dbSet;

        protected EfEntityRepositoryBase(GenericContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _dbSet.AsNoTracking().ToList()
                : _dbSet.Where(filter).AsNoTracking().ToList();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _dbSet.AsNoTracking()
                : _dbSet.Where(filter).AsNoTracking();
        }

        public virtual T GetFindById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            if (Count() > 0)
                return _dbSet.FirstOrDefault(filter);
            return null;
        }

        public IQueryable<T> Table => this.Entities;

        protected virtual DbSet<T> Entities
        {
            get { return _dbSet; }
        }

        public virtual IQueryable<T> GetListPaging(Expression<Func<T, bool>> filter, out int total, int index, int size)
        {
            var skipCount = index * size;
            var resetSet = filter != null
                ? _dbSet.AsNoTracking().Where(filter).AsQueryable()
                : _dbSet.AsNoTracking().AsQueryable();

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);

            total = resetSet.Count();

            return resetSet;
        }

        public virtual T Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return _dbSet.Add(entity).Entity;
        }

        public virtual T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var updateEntity = _context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            return updateEntity.Entity;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public int Count()
        {
            return _dbSet.AsNoTracking().Count();
        }

        public virtual async Task<T> GetFindByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            if (Count() > 0)
                return await _dbSet.FirstOrDefaultAsync(filter);
            return null;
        }

        public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? await _dbSet.AsNoTracking().ToListAsync()
                : await _dbSet.Where(filter).AsNoTracking().ToListAsync();
        }

        public virtual void AddRange(IEnumerable<T> listEntity)
        {
            if (listEntity == null)
                throw new ArgumentNullException("listEntity");

            foreach (var entity in listEntity)
            {
                _dbSet.Add(entity);
            }
        }

        public virtual void UpdateAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null) return;
            var getDeleteList = GetList(filter);
            foreach (var item in getDeleteList)
            {
                Update(item);
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> filter)
        {
            var entity = Get(filter);
            if (entity == null) return;

            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual void DeleteAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null) return;
            var getDeleteList = GetList(filter);
            foreach (var item in getDeleteList)
            {
                Delete(item);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}