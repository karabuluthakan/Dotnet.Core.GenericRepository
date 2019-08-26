using Dotnet.Core.Common.Business;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Business.Abstract
{
    public interface IRegionService : IEntityService<Region>
    {
        bool IsExistName(string name);
    }
}