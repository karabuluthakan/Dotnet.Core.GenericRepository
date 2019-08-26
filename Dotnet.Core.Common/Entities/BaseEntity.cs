using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet.Core.Common.Entities
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key, Column("id", Order = 0)] public virtual TKey Id { get; set; }
    }
}