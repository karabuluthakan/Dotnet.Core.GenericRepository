using Dotnet.Core.Business.Abstract;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Core.Api.Controllers.Odata
{
    [Produces("application/json")]
    public class RegionsController:ODataController
    {
        private IRegionService _service;

        public RegionsController(IRegionService service)
        {
            _service = service;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_service.GetQueryable());
        }

        [EnableQuery]
        public IActionResult Get([FromODataUri]int id)
        {
            return Ok(_service.GetQueryable(x => x.Id == id));
        }
    }
}