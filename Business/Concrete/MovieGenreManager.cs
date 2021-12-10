using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieGenreManager : BaseManager<MovieGenre>, IMovieGenreService
    {
        private IMovieGenreDal _movieGenreDal;

        public MovieGenreManager(IMovieGenreDal movieGenreDal) : base(movieGenreDal)
        {
            _movieGenreDal = movieGenreDal;
        }
    }
}
