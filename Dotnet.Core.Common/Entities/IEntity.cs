using Dotnet.Core.Common.Enums;

namespace Dotnet.Core.Common.Entities
{
    public interface IEntity
    {
        StatusEnum Status { get; set; }
    }
}