using System.ComponentModel;

namespace Dotnet.Core.Common.Enums
{
    [DefaultValue(Active)]
    public enum StatusEnum
    {
        Active = 1,
        Passive = 2,
        Hold = 3,
        Done = 4,
        Deleted = 5
    }
}