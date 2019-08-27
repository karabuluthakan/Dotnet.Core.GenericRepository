using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Api;
using Dotnet.Core.Common.Contracts;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Dto.V1.UpdateDtos;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Core.Api.Controllers.V1
{
    public class CitiesController : GenericController<City, CityForListDto, CityForCreateDto, CityForUpdateDto>
    {
        private readonly ICityService _service;

        public CitiesController(ICityService cityService, IMapper mapper) : base(mapper, cityService)
        {
            _service = cityService;
        }

        [HttpGet(Routes.Cities.Details)]
        public IActionResult CityForDetailList()
        {
            var data = _service.CityForDetailList();
            return Ok(data);
        }

        [HttpGet(Routes.Cities.GetAll)]
        public override IActionResult Index()
        {
            return base.Index();
        }

        [HttpGet(Routes.Cities.GetById)]
        public override IActionResult Show(int id)
        {
            return base.Show(id);
        }

        [HttpPost(Routes.Cities.Create)]
        public override Task<IActionResult> CreateAsync(CityForCreateDto item)
        {
            return base.CreateAsync(item);
        }

        [HttpPut(Routes.Cities.Update)]
        public override Task<IActionResult> UpdateAsync(int id, CityForUpdateDto item)
        {
            return base.UpdateAsync(id, item);
        }

        [HttpDelete(Routes.Cities.Force)]
        public override Task<IActionResult> DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
    }
}