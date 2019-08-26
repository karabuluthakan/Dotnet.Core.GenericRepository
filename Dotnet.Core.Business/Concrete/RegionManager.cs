using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Business;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Business.Concrete
{
    public class RegionManager : EntityManager<Region>, IRegionService
    {
        private readonly IRegionDal _regionDal;

        private readonly IUnitOfWork _unitOfWork;

        public RegionManager(IRegionDal regionDal, IUnitOfWork unitOfWork) : base(regionDal,
            unitOfWork)
        {
            _regionDal = regionDal;
            _unitOfWork = unitOfWork;
        }

        public bool IsExistName(string name)
        {
            var exist = _regionDal.Get(x => x.Name == name);
            if (exist != null)
                return true;
            return false;
        }
    }
}