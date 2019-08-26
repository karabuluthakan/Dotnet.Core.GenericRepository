using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.DataAccess.Abstract.EntityFramework;
using Dotnet.Core.DataAccess.Context;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.DataAccess.Concrete.EntityFramework
{
    public class EfContinentalDal : EfEntityRepositoryBase<Continental>, IContinentalDal
    {
        public EfContinentalDal(GenericContext context) : base(context)
        {
        }
    }
}