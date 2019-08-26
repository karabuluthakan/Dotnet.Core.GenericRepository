using System.Collections.Generic;
using System.Linq;
using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.DataAccess.Abstract.EntityFramework;
using Dotnet.Core.DataAccess.Context;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : EfEntityRepositoryBase<City>, ICityDal
    {
        public EfCityDal(GenericContext context) : base(context)
        {
        }

        public List<CityForListDto> CityForDetailList()
        {
            var result = (from city in _context.Cities
                join country in _context.Countries
                    on city.CountryId equals country.Id
                join region in _context.Regions
                    on country.RegionId equals region.Id
                join continental in _context.Continentals
                    on region.ContinentalId equals continental.Id
                select new CityForListDto
                {
                    Id = city.Id,
                    CityId = city.Id,
                    CountryId = country.Id,
                    RegionId = region.Id,
                    ContinentalId = continental.Id,
                    CountryName = country.Name,
                    CityName = city.Name,
                    RegionName = region.Name,
                    ContinentalName = continental.Name
                }).OrderByDescending(x => x.ContinentalId);

            return result.ToList();
        }
    }
}