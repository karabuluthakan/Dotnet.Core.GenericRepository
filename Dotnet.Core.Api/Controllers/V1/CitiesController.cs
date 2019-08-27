using AutoMapper;
using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Api;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Dto.V1.UpdateDtos;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Api.Controllers.V1
{
    public class CitiesController : GenericController<City, CityForListDto, CityForCreateDto, CityForUpdateDto>
    {
        private readonly ICityService _service;

        public CitiesController(ICityService cityService, IMapper mapper) : base(mapper, cityService)
        {
            _service = cityService;
        }
    }
}