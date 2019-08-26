using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.DataAccess.Abstract.EntityFramework;
using Dotnet.Core.DataAccess.Context;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.DataAccess.Concrete.EntityFramework
{
    public class EfRegionDal : EfEntityRepositoryBase<Region>, IRegionDal
    {
        public EfRegionDal(GenericContext context) : base(context)
        {
        }
    }
}