using System;
using System.Threading.Tasks;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.DataAccess.Context; 

namespace Dotnet.Core.DataAccess.Abstract.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private GenericContext _context;

        public EfUnitOfWork(GenericContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            var transId = -1;
            if (_context != null)
            {
                if (_context.ChangeTracker.HasChanges())
                {
                    using (var dbContextTransaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            transId = _context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            throw new Exception(ex.ToString());
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_context));
            }

            return transId;
        }

        public async Task<int> CommitAsync()
        {
            var transId = -1;
            if (_context != null)
            {
                if (_context.ChangeTracker.HasChanges())
                {
                    using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            transId = await _context.SaveChangesAsync();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            throw new Exception(ex.ToString());
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_context));
            }

            return transId;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}