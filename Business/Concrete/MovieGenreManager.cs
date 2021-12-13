using Business.Abstract;
using Core.Business;
using Core.Utils.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult DeleteByMovie(int movieId)
        {
            try
            {
                _movieGenreDal.DeleteByMovieId(movieId);
                return new SuccessResult("Film Türleri silindi");
            } 
            catch(Exception ex) 
            {
                return new ErrorResult(ex.Message); 
            }
        }
    }
}
