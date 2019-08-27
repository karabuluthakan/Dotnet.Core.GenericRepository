using System;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.Core.Common.Business;
using Dotnet.Core.Common.Contracts;
using Dotnet.Core.Common.Entities;
using Dotnet.Core.Common.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Core.Common.Presentation
{
    [Produces("application/json")]
    [ApiController]
    public class GenericController<TEntity, TListDto, TCreateDto, TEditDto> : ControllerBase
        where TEditDto : class, IEntityDto, new()
        where TCreateDto : class, IEntityDto, new()
        where TListDto : class, IEntityDto, new()
        where TEntity : class, IEntity, new()
    {
        private readonly IMapper _mapper;
        private readonly IEntityService<TEntity> _service;
        private static string ClassFullName => typeof(TEntity).Name;

        public GenericController(IEntityService<TEntity> entityService, IMapper mapper)
        {
            _service = entityService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            var result = new Result<TListDto>();
            var data = _service.GetList();

            if (data.ResultObject == null)
            {
                result.ResultMessage = data.ResultMessage;
                result.ResultInnerMessage = data.ResultInnerMessage;
                result.ResultCode = data.ResultCode;
                result.ResultStatus = data.ResultStatus;
                result.ResultObject = null;
                return NotFound(result);
            }

            var mapping = _mapper.Map<TListDto>(data);
            try
            {
                result.ResultMessage = data.ResultMessage;
                result.ResultInnerMessage = data.ResultInnerMessage;
                result.ResultCode = data.ResultCode;
                result.ResultStatus = data.ResultStatus;
                result.ResultObject = mapping;

                return Ok(result);
            }
            catch (Exception e)
            {
                result.ResultCode = data.ResultCode;
                result.ResultStatus = data.ResultStatus;
                result.ResultMessage = e.Message;
                result.ResultInnerMessage = e.InnerException?.ToString();
                result.ResultObject = mapping;
                return BadRequest(result);
            }
        }

        [HttpGet]
        public virtual IActionResult Show([FromRoute] int id)
        {
            var result = new Result<TListDto>();
            var data = _service.GetFindById(id);
            if (data == null)
            {
                result.ResultMessage = $"No records with id => {id}";
                result.ResultInnerMessage = $"There is no record with this id => {id} in the '{ClassFullName}' model";
                result.ResultCode = (int) ResultStatusCode.NotFound;
                result.ResultStatus = false;
                result.ResultObject = null;
                return NotFound(result);
            }

            var mapping = _mapper.Map<TListDto>(data);
            try
            {
                result.ResultObject = mapping;
                result.ResultCode = data.ResultCode;
                result.ResultStatus = data.ResultStatus;
                result.ResultMessage = data.ResultMessage;
                result.ResultInnerMessage = data.ResultInnerMessage;
                if (data.ResultCode == (int) ResultStatusCode.Ok)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception e)
            {
                result.ResultObject = mapping;
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultStatus = false;
                result.ResultMessage = e.Message;
                result.ResultInnerMessage = e.InnerException?.ToString();
                return BadRequest(result);
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync(TCreateDto item)
        {
            var mapping = _mapper.Map<TEntity>(item);
            var result = new Result<TEntity>();
            try
            {
                var data = await _service.AddAsync(mapping);
                result.ResultObject = mapping;
                result.ResultCode = data.ResultCode;
                result.ResultStatus = data.ResultStatus;
                result.ResultMessage = data.ResultMessage;
                result.ResultInnerMessage = data.ResultInnerMessage;
                if (data.ResultCode == (int) ResultStatusCode.Created)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception e)
            {
                result.ResultObject = mapping;
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultStatus = false;
                result.ResultMessage = e.Message;
                result.ResultInnerMessage = e.InnerException?.ToString();
                return BadRequest(result);
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync([FromRoute] int id, TEditDto item)
        {
            var result = new Result<TEntity>();
            var data = await _service.GetFindByIdAsync(id);
            if (data == null)
            {
                result.ResultMessage = $"No records with id => {id}";
                result.ResultInnerMessage = $"There is no record with this id => {id} in the '{ClassFullName}' model";
                result.ResultCode = (int) ResultStatusCode.NotFound;
                result.ResultStatus = false;
                result.ResultObject = null;
                return NotFound(result);
            }

            var mapping = _mapper.Map(item, data);

            try
            {
                var update = _service.Update(mapping);
                result.ResultObject = mapping;
                result.ResultCode = update.ResultCode;
                result.ResultStatus = update.ResultStatus;
                result.ResultMessage = update.ResultMessage;
                result.ResultInnerMessage = update.ResultInnerMessage;
                if (update.ResultCode == (int) ResultStatusCode.Updated)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception e)
            {
                result.ResultObject = mapping;
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultStatus = false;
                result.ResultMessage = e.Message;
                result.ResultInnerMessage = e.InnerException?.ToString();
                return BadRequest(result);
            }
        }

        [HttpDelete]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var result = new Result<TEntity>();
            var data = await _service.GetFindByIdAsync(id);
            if (data == null)
            {
                result.ResultMessage = $"No records with id => {id}";
                result.ResultInnerMessage = $"There is no record with this id => {id} in the '{ClassFullName}' model";
                result.ResultCode = (int) ResultStatusCode.NotFound;
                result.ResultStatus = false;
                result.ResultObject = null;
                return NotFound(result);
            }

            try
            {
                var delete = _service.Delete(data);
                result.ResultObject = data;
                result.ResultCode = delete.ResultCode;
                result.ResultStatus = delete.ResultStatus;
                result.ResultMessage = delete.ResultMessage;
                result.ResultInnerMessage = delete.ResultInnerMessage;
                if (delete.ResultCode == (int) ResultStatusCode.Deleted)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception e)
            {
                result.ResultObject = data;
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultStatus = false;
                result.ResultMessage = e.Message;
                result.ResultInnerMessage = e.InnerException?.ToString();
                return BadRequest(result);
            }
        }
    }
}