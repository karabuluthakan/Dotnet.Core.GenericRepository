using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.DataAccess.Abstract.EntityFramework;
using Dotnet.Core.DataAccess.Context;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.DataAccess.Concrete.EntityFramework
{
    public class EfCountryDal : EfEntityRepositoryBase<Country>, ICountryDal
    {
        public EfCountryDal(GenericContext context) : base(context)
        {
        }
    }
}