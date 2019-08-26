using System.ComponentModel.DataAnnotations;

namespace Dotnet.Core.Common.Entities
{
    public interface IBaseEntity<TKey> : IEntity
    {
        [Key] TKey Id { get; set; }
    }
}