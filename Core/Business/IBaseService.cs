using Core.Entities;
using Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IBaseService<T> where T:IEntity
    {
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);

        IDataResult<T> Get(Expression<Func<T, bool>> filter);

        IDataResult<T> GetById(int id);

        Result Add(T entity);

        Result Update(T entity);

        Result Delete(T entity);
    }
}
