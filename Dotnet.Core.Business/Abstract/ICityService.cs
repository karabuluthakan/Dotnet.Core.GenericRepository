using System.Collections.Generic;
using Dotnet.Core.Common.Business;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Business.Abstract
{
    public interface ICityService : IEntityService<City>
    {
        bool IsExistName(string name);
        List<CityForListDto> CityForDetailList();
    }
}