using Dotnet.Core.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Core.DataAccess.Mappings.Abstract
{
    public interface IEntitySimpleMapping<TKey, TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IBaseEntity<TKey>, new()
    {
    }
}