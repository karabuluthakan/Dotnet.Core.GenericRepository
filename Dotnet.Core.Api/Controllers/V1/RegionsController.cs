using AutoMapper;
using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Api;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Dto.V1.UpdateDtos;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Api.Controllers.V1
{
    public class RegionsController : GenericController<Region, RegionForListDto, RegionForCreateDto,
        RegionForUpdateDto>
    {
        private readonly IRegionService _service;

        public RegionsController(IRegionService regionService, IMapper mapper) : base(mapper, regionService)
        {
            _service = regionService;
        }
    }
}