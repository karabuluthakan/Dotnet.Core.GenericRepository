using System;
using System.Linq;
using AutoMapper;
using Dotnet.Core.Common.Business;
using Dotnet.Core.Common.Contracts;
using Dotnet.Core.Common.Entities;
using Dotnet.Core.Common.Entities.Dto;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Core.Common.Presentation
{
    [Produces("application/json")]
    [ApiController]
    public abstract class GenericODataController<TEntity> : ODataController
        where TEntity : class, IEntity, new()
    {
        private readonly IMapper _mapper;
        private readonly IEntityService<TEntity> _service;
        private static string ClassFullName => typeof(TEntity).Name;

        protected GenericODataController(IEntityService<TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [EnableQuery]
        public virtual IActionResult Get()
        {
            var data = _service.GetAll();

            if (data == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}