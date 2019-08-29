using Dotnet.Core.Business.Abstract;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Core.Api.Controllers.Odata
{
    [Produces("application/json")] 
    public class CitiesController : ODataController
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_cityService.GetAll());
        }
    }
}