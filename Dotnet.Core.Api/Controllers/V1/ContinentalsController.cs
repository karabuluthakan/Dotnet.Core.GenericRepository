using AutoMapper;
using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Api;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Dto.V1.UpdateDtos;
using Dotnet.Core.Entities.Geolocation;

namespace Dotnet.Core.Api.Controllers.V1
{
    public class ContinentalsController : GenericController<Continental, ContinentalForListDto, ContinentalForCreateDto,
        ContinentalForUpdateDto>
    {
        private readonly IContinentalService _service;

        public ContinentalsController(IContinentalService continentalService, IMapper mapper) : base(mapper,
            continentalService)
        {
            _service = continentalService;
        }
    }
}