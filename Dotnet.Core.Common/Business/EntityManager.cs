using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dotnet.Core.Common.Contracts;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.Common.Entities;

namespace Dotnet.Core.Common.Business
{
    public abstract class EntityManager<T> : IEntityService<T>, IDisposable where T : class, IEntity, new()
    {
        private string ClassFullName => typeof(T).FullName;
        private readonly IEntityRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected EntityManager(IEntityRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null)
        {
            return _repository.GetQueryable(filter);
        }

        public virtual Result<T> GetFindById(object id)
        {
            var result = new Result<T>();
            try
            {
                result.ResultCode = (int) ResultStatusCode.Ok;
                result.ResultMessage = $"'{ClassFullName}' successfully listed";
                result.ResultStatus = true;
                result.ResultObject = _repository.GetFindById(id);
                result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = null;
            }

            return result;
        }

        public virtual Result<T> Get(Expression<Func<T, bool>> filter)
        {
            var result = new Result<T>();
            try
            {
                result.ResultCode = (int) ResultStatusCode.Ok;
                result.ResultMessage = $"'{ClassFullName}' successfully listed";
                result.ResultStatus = true;
                result.ResultObject = _repository.Get(filter);
                result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = null;
            }

            return result;
        }

        public virtual Result<IEnumerable<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            var result = new Result<IEnumerable<T>>();
            try
            {
                var data = _repository.GetList(filter);
                if (data != null)
                {
                    result.ResultCode = (int) ResultStatusCode.Ok;
                    result.ResultMessage = $"'{ClassFullName}' successfully listed";
                    result.ResultStatus = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                    result.ResultObject = data;
                }
                else
                {
                    result.ResultCode = (int) ResultStatusCode.NotFound;
                    result.ResultMessage = $"'{ClassFullName}' no content";
                    result.ResultStatus = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                    result.ResultObject = null;
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual Result<IEnumerable<T>> GetListPaging(Expression<Func<T, bool>> filter,
            out int total,
            int index = 0,
            int size = 15)
        {
            var result = new Result<IEnumerable<T>>();

            try
            {
                result.ResultObject = _repository.GetListPaging(filter, out total, index, size);
                result.ResultCode = (int) ResultStatusCode.Ok;
                result.ResultMessage = $"'{ClassFullName}' successfully paging listed";
                result.ResultStatus = true;
                result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
            }
            catch (Exception ex)
            {
                total = 0;
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = null;
            }

            return result;
        }

        public virtual Result<T> Add(T entity)
        {
            var result = new Result<T>();
            try
            {
                var adding = _repository.Add(entity);
                var uow = _unitOfWork.Commit();
                if (uow > 0)
                {
                    result.ResultObject = adding;
                    result.ResultCode = (int) ResultStatusCode.Created;
                    result.ResultMessage = $"'{ClassFullName}' successfully created";
                    result.ResultStatus = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
                else
                {
                    result.ResultObject = adding;
                    result.ResultCode = (int) ResultStatusCode.BadRequest;
                    result.ResultMessage = $"'{ClassFullName}' not created";
                    result.ResultStatus = false;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = null;
            }

            return result;
        }

        public virtual Result<bool> AddRange(IEnumerable<T> listEntity)
        {
            var result = new Result<bool>();
            try
            {
                _repository.AddRange(listEntity);
                var uow = _unitOfWork.Commit();
                if (uow > 0)
                {
                    result.ResultCode = (int) ResultStatusCode.Ok;
                    result.ResultMessage = $"'{ClassFullName}' successfully added";
                    result.ResultStatus = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                    result.ResultObject = true;
                }
                else
                {
                    result.ResultCode = (int) ResultStatusCode.BadRequest;
                    result.ResultMessage = $"'{ClassFullName}' not added";
                    result.ResultStatus = false;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                    result.ResultObject = false;
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = false;
            }

            return result;
        }

        public virtual Result<T> Update(T entity)
        {
            var result = new Result<T>();
            try
            {
                var data = _repository.Update(entity);
                var uow = _unitOfWork.Commit();
                if (uow > 0)
                {
                    result.ResultObject = data;
                    result.ResultCode = (int) ResultStatusCode.Updated;
                    result.ResultMessage = $"'{ClassFullName}' successfully updated";
                    result.ResultStatus = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
                else
                {
                    result.ResultObject = data;
                    result.ResultCode = (int) ResultStatusCode.BadRequest;
                    result.ResultMessage = $"'{ClassFullName}' not updated";
                    result.ResultStatus = false;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = null;
            }

            return result;
        }

        public virtual Result<bool> Delete(T entity)
        {
            var result = new Result<bool>();
            try
            {
                _repository.Delete(entity);
                var uow = _unitOfWork.Commit();

                if (uow > 0)
                {
                    result.ResultCode = (int) ResultStatusCode.Deleted;
                    result.ResultMessage = $"'{ClassFullName}' successfully deleted";
                    result.ResultStatus = true;
                    result.ResultObject = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
                else
                {
                    result.ResultCode = (int) ResultStatusCode.BadRequest;
                    result.ResultMessage = $"'{ClassFullName}' not deleted";
                    result.ResultStatus = false;
                    result.ResultObject = false;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultObject = false;
                result.ResultStatus = false;
            }

            return result;
        }

        public virtual bool Delete(Expression<Func<T, bool>> filter)
        {
            var result = new Result<bool>();

            _repository.Delete(filter);
            var uow = _unitOfWork.Commit();

            if (uow > 0)
                result.ResultStatus = true;
            else
                result.ResultStatus = false;

            return result.ResultStatus;
        }

        public virtual bool DeleteAll(Expression<Func<T, bool>> filter = null)
        {
            var result = new Result<bool>();

            _repository.DeleteAll(filter);
            var uow = _unitOfWork.Commit();

            if (uow > 0)
                result.ResultStatus = true;
            else
                result.ResultStatus = false;


            return result.ResultStatus;
        }

        public virtual async Task<T> GetFindByIdAsync(object id)
        {
            var data = await _repository.GetFindByIdAsync(id);
            if (data != null)
                return data;
            return null;
        }

        public virtual async Task<Result<T>> GetAsync(Expression<Func<T, bool>> filter = null)
        {
            var result = new Result<T>();
            try
            {
                var data = await _repository.GetAsync(filter);
                if (data != null)
                {
                    result.ResultCode = (int) ResultStatusCode.Ok;
                    result.ResultMessage = $"'{ClassFullName}' successfully showed";
                    result.ResultStatus = true;
                    result.ResultObject = data;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
                else
                {
                    result.ResultCode = (int) ResultStatusCode.NotFound;
                    result.ResultMessage = $"'{ClassFullName}' not found";
                    result.ResultStatus = false;
                    result.ResultObject = null;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = null;
            }

            return result;
        }

        public virtual async Task<Result<T>> AddAsync(T entity)
        {
            var result = new Result<T>();
            try
            {
                var data = _repository.Add(entity);
                var uow = await _unitOfWork.CommitAsync();
                if (uow > 0)
                {
                    result.ResultObject = data;
                    result.ResultCode = (int) ResultStatusCode.Created;
                    result.ResultMessage = $"'{ClassFullName}' successfully created";
                    result.ResultStatus = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
                else
                {
                    result.ResultObject = null;
                    result.ResultCode = (int) ResultStatusCode.BadRequest;
                    result.ResultMessage = $"'{ClassFullName}' not created";
                    result.ResultStatus = false;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = null;
            }

            return result;
        }

        public virtual async Task<Result<T>> UpdateAsync(T entity)
        {
            var result = new Result<T>();
            try
            {
                var data = _repository.Update(entity);
                var uow = await _unitOfWork.CommitAsync();
                if (uow > 0)
                {
                    result.ResultObject = data;
                    result.ResultCode = (int) ResultStatusCode.Updated;
                    result.ResultMessage = $"'{ClassFullName}' successfully updated";
                    result.ResultStatus = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
                else
                {
                    result.ResultObject = data;
                    result.ResultCode = (int) ResultStatusCode.BadRequest;
                    result.ResultMessage = $"'{ClassFullName}' not updated";
                    result.ResultStatus = false;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultStatus = false;
                result.ResultObject = null;
            }

            return result;
        }

        public virtual async Task<Result<bool>> DeleteAsync(T entity)
        {
            var result = new Result<bool>();
            try
            {
                _repository.Delete(entity);
                var uow = await _unitOfWork.CommitAsync();
                if (uow > 0)
                {
                    result.ResultCode = (int) ResultStatusCode.Deleted;
                    result.ResultMessage = $"'{ClassFullName}' successfully deleted";
                    result.ResultObject = true;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                    result.ResultStatus = true;
                }
                else
                {
                    result.ResultCode = (int) ResultStatusCode.BadRequest;
                    result.ResultMessage = $"'{ClassFullName}' not deleted";
                    result.ResultObject = false;
                    result.ResultInnerMessage = $"'{result.ResultMessage}' => {result.ResultObject}";
                    result.ResultStatus = false;
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = (int) ResultStatusCode.BadRequest;
                result.ResultMessage = ex.Message;
                result.ResultInnerMessage = ex.InnerException?.ToString();
                result.ResultObject = false;
                result.ResultStatus = false;
            }

            return result;
        }

        public void Dispose()
        {
            _repository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}