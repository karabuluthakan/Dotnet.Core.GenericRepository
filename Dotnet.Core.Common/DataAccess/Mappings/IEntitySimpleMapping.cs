using Dotnet.Core.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Core.Common.DataAccess.Mappings
{
    public interface IEntitySimpleMapping<TKey, TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IBaseEntity<TKey>, new()
    {
    }
}