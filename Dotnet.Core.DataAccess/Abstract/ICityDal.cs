using System.Collections.Generic;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.DataAccess.Abstract
{
    public interface ICityDal : IEntityRepository<City>
    {
        List<CityForListDto> CityForDetailList();
    }
}