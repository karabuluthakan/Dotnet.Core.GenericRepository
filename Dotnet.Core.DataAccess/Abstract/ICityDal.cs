using Dotnet.Core.Common.DataAccess; 
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.DataAccess.Abstract
{
    public interface ICityDal : IEntityRepository<City>
    {
    }
}