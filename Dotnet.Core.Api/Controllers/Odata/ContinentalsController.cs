using System;
using Dotnet.Core.Business.Abstract;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet.Core.Api.Controllers.Odata
{
    [Produces("application/json")]
    public class ContinentalsController : ODataController
    {
        private readonly IContinentalService _service;

        private readonly ILogger<ContinentalsController> _logger;

        public ContinentalsController(IContinentalService service, ILogger<ContinentalsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [EnableQuery(MaxExpansionDepth = 8)]
        public virtual IActionResult Get()
        {
            var data = _service.GetAll();

            if (data == null)
            {
                _logger.LogError($"continentals not found : {DateTime.UtcNow}");
                return NotFound();
            }

            try
            {
                _logger.LogInformation($"continentals displayed : {DateTime.UtcNow}");
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError($"continentals catch Exception : {DateTime.UtcNow}");
                return BadRequest(e);
            }
        }
    }
}