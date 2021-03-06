using Core.Business;
using Core.Utils.Results;
using Entities.Dtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieService : IBaseService<Movie>
    {
        IResult AddWithGenres(AddMovieDto dto);

        IDataResult<List<MovieDto>> GetMoviesByDetails();
        IDataResult<MovieDto> GetDetail(int movieId);
        IResult EditWithGenres(AddMovieDto addMovieDto);
    }
}
