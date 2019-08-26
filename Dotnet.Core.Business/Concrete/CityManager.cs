using System.Collections.Generic;
using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Business;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Business.Concrete
{
    public class CityManager : EntityManager<City>, ICityService
    {
        private readonly ICityDal _cityDal;
        private readonly IUnitOfWork _unitOfWork;

        public CityManager(ICityDal cityDal, IUnitOfWork unitOfWork) : base(cityDal, unitOfWork)
        {
            _cityDal = cityDal;
            _unitOfWork = unitOfWork;
        }
        
        public bool IsExistName(string name)
        {
            var exist = _cityDal.Get(x => x.Name == name);
            if (exist != null)
                return true;
            return false;
        }

        public List<CityForListDto> CityForDetailList()
        {
            return _cityDal.CityForDetailList();
        }
    }
}