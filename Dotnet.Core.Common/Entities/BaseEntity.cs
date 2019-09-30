using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dotnet.Core.Common.Enums;

namespace Dotnet.Core.Common.Entities
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key, Column("id", Order = 0)] public virtual TKey Id { get; set; }
        
        [Column("status", Order = 4), MaxLength(2), DefaultValue(StatusEnum.Active)]
        public StatusEnum Status { get; set; }
    }
}