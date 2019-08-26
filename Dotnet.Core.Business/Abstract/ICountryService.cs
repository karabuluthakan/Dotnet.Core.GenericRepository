using Dotnet.Core.Common.Business;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Business.Abstract
{
    public interface ICountryService : IEntityService<Country>
    {
        bool IsExistName(string name);
    }
}