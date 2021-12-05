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
    public class MovieManager : BaseManager<Movie>, IMovieService
    {
        private IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal) : base(movieDal)
        {
            _movieDal = movieDal;
        }
    }
}
