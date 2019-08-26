using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Business;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Business.Concrete
{
    public class CountryManager : EntityManager<Country>, ICountryService
    {
        private readonly ICountryDal _countryDal;

        private readonly IUnitOfWork _unitOfWork;

        public CountryManager(ICountryDal countryDal, IUnitOfWork unitOfWork) : base(countryDal,
            unitOfWork)
        {
            _countryDal = countryDal;
            _unitOfWork = unitOfWork;
        }

        public bool IsExistName(string name)
        {
            var exist = _countryDal.Get(x => x.Name == name);
            if (exist != null)
                return true;
            return false;
        }
    }
}