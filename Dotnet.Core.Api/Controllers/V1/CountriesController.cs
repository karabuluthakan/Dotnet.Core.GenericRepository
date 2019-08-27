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
    public class CountriesController : GenericController<Country, CountryForListDto, CountryForCreateDto,
        CountryForUpdateDto>
    {
        private readonly ICountryService _service;

        public CountriesController(ICountryService countryService, IMapper mapper) : base(mapper, countryService)
        {
            _service = countryService;
        }

        [HttpGet(Routes.Countries.GetAll)]
        public override IActionResult Index()
        {
            return base.Index();
        }

        [HttpGet(Routes.Countries.GetById)]
        public override IActionResult Show(int id)
        {
            return base.Show(id);
        }

        [HttpPost(Routes.Countries.Create)]
        public override Task<IActionResult> CreateAsync(CountryForCreateDto item)
        {
            return base.CreateAsync(item);
        }

        [HttpPut(Routes.Countries.Update)]
        public override Task<IActionResult> UpdateAsync(int id, CountryForUpdateDto item)
        {
            return base.UpdateAsync(id, item);
        }

        [HttpDelete(Routes.Countries.Force)]
        public override Task<IActionResult> DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
    }
}