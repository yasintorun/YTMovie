using Core.Business;
using Core.Utils.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService : IBaseService<Comment>
    {
        IDataResult<List<Comment>> GetByMovieId(int movieId);
        IResult ChangeStatus(int id);
        IDataResult<List<CommentDto>> GetAllDetails();
    }
}
