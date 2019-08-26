using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet.Core.Common.Entities
{
    public abstract class EntitySimple<T> : BaseEntity<T>,IEntitySimple<T>
    {
        [Column("name", Order = 1, TypeName = "varchar(50)")]
        public string Name { get; set; }
    }
}