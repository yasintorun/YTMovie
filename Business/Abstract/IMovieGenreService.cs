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
    public interface IMovieGenreService : IBaseService<MovieGenre>
    {
        IResult DeleteByMovie(int movieId);
    }
}
