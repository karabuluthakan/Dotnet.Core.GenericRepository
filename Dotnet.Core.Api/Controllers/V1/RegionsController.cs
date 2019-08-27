using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Common.Contracts;
using Dotnet.Core.Common.Presentation;
using Dotnet.Core.Entities.Dto.V1.CreateDtos;
using Dotnet.Core.Entities.Dto.V1.ListDtos;
using Dotnet.Core.Entities.Dto.V1.UpdateDtos;
using Dotnet.Core.Entities.Geolocation;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Core.Api.Controllers.V1
{
    public class RegionsController : GenericController<Region, RegionForListDto, RegionForCreateDto,
        RegionForUpdateDto>
    {
        private readonly IRegionService _service;

        public RegionsController(IRegionService regionService, IMapper mapper) : base(regionService, mapper)
        {
            _service = regionService;
        }

        [HttpGet(Routes.Regions.GetAll)]
        public override IActionResult Index()
        {
            return base.Index();
        }

        [HttpGet(Routes.Regions.GetById)]
        public override IActionResult Show(int id)
        {
            return base.Show(id);
        }

        [HttpPost(Routes.Regions.Create)]
        public override Task<IActionResult> CreateAsync(RegionForCreateDto item)
        {
            return base.CreateAsync(item);
        }

        [HttpPut(Routes.Regions.Update)]
        public override Task<IActionResult> UpdateAsync(int id, RegionForUpdateDto item)
        {
            return base.UpdateAsync(id, item);
        }

        [HttpDelete(Routes.Regions.Force)]
        public override Task<IActionResult> DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
    }
}