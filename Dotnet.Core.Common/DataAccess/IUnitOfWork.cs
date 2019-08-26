using System;
using System.Threading.Tasks;

namespace Dotnet.Core.Common.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
    }
}