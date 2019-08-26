using Dotnet.Core.Common.Business;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Business.Abstract
{
    public interface IContinentalService:IEntityService<Continental>
    {
        bool IsExistName(string name);
    }
}