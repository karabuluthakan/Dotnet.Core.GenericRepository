using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Business;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Business.Concrete
{
    public class ContinentalManager : EntityManager<Continental>, IContinentalService
    {
        private readonly IContinentalDal _continentalDal;

        private readonly IUnitOfWork _unitOfWork;

        public ContinentalManager(IContinentalDal continentalDal, IUnitOfWork unitOfWork) : base(continentalDal,
            unitOfWork)
        {
            _continentalDal = continentalDal;
            _unitOfWork = unitOfWork;
        }

        public bool IsExistName(string name)
        {
            var exist = _continentalDal.Get(x => x.Name == name);
            if (exist != null)
                return true;
            return false;
        }
    }
}