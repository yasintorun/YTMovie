using Core.Business;
using Core.Utils.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenreService : IBaseService<Genre>
    {
        IResult ChangeStatus(int id);
    }
}
