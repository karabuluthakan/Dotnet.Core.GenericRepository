using Dotnet.Core.Business.Abstract;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Core.Api.Controllers.Odata
{
    [Produces("application/json")]
    public class CountriesController : ODataController
    {
        private readonly ICountryService _service;

        public CountriesController(ICountryService service)
        {
            _service = service;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        } 
    }
}