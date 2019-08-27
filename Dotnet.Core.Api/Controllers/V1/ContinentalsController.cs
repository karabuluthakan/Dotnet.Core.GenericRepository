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
    public class ContinentalsController : GenericController<Continental, ContinentalForListDto, ContinentalForCreateDto,
        ContinentalForUpdateDto>
    {
        private readonly IContinentalService _service;

        public ContinentalsController(IContinentalService continentalService, IMapper mapper) : base(continentalService,mapper)
        {
            _service = continentalService;
        }

        [HttpGet(Routes.Continentals.GetAll)]
        public override IActionResult Index()
        {
            return base.Index();
        }

        [HttpGet(Routes.Continentals.GetById)]
        public override IActionResult Show(int id)
        {
            return base.Show(id);
        }

        [HttpPost(Routes.Continentals.Create)]
        public override Task<IActionResult> CreateAsync(ContinentalForCreateDto item)
        {
            return base.CreateAsync(item);
        }

        [HttpPut(Routes.Continentals.Update)]
        public override Task<IActionResult> UpdateAsync(int id, ContinentalForUpdateDto item)
        {
            return base.UpdateAsync(id, item);
        }

        [HttpDelete(Routes.Continentals.Force)]
        public override Task<IActionResult> DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
    }
}