using Core.DataAccess;
using Core.Entities;
using Core.Entities.Concrete;
using Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public abstract class BaseManager<T> : IBaseService<T> where T : BaseEntity
    {
        private IEntityRepository<T> _entityRepository;
        public BaseManager(IEntityRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public Result Add(T entity)
        {
           // try
           // {
                _entityRepository.Add(entity);
                return new SuccessResult("Eklendi");
            /*} catch(Exception e)
            {
                return new ErrorResult(e.Message);
            }*/
        }

        public Result Delete(T entity)
        {
            try
            {
                _entityRepository.Delete(entity);
                return new SuccessResult("Silindi");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IDataResult<T> Get(Expression<Func<T, bool>> filter)
        {
            try
            {
                return new SuccessDataResult<T>(_entityRepository.Get(filter), "Getirildi");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<T>(e.Message);
            }
        }

        public IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                return new SuccessDataResult<List<T>>(_entityRepository.GetAll(filter), "Getirildi");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<T>>(e.Message);
            }
        }

        public IDataResult<T> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<T>(_entityRepository.Get(e => e.Id == id), "Getirildi");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<T>(e.Message);
            }
        }

        public Result Update(T entity)
        {
            try
            {
                _entityRepository.Update(entity);
                return new SuccessResult("Güncellendi");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
