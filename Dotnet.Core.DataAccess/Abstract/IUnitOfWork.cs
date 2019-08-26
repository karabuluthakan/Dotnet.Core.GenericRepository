using System;
using System.Threading.Tasks;

namespace Dotnet.Core.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
    }
}