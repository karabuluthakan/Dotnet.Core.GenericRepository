using AutoMapper;
using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Api;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Dto.V1.UpdateDtos;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Api.Controllers.V1
{
    public class CountriesController : GenericController<Country, CountryForListDto, CountryForCreateDto,
        CountryForUpdateDto>
    {
        private readonly ICountryService _service;

        public CountriesController(ICountryService countryService, IMapper mapper) : base(mapper, countryService)
        {
            _service = countryService;
        }
    }
}