using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Core.Business;
using Core.Utils.Results;
using DataAccess.Abstract;
using Entities.Dtos;
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
        private IMovieGenreService _movieGenreService = InstanceFactory.GetInstance<IMovieGenreService>();

        public MovieManager(IMovieDal movieDal) : base(movieDal)
        {
            _movieDal = movieDal;
        }

        public IResult AddWithGenres(AddMovieDto dto)
        {
            var addResult = this.Add(dto.Movie);
            if(addResult == null || !addResult.Success)
            {
                return addResult;
            }
            foreach (var genreId in dto.GenreIds)
            {
                _movieGenreService.Add(new MovieGenre()
                {
                    GenreId = genreId,
                    MovieId = dto.Movie.Id,
                });
            }
            return addResult;
        }

        public IDataResult<List<MovieDto>> GetMovieDetails()
        {
            return new SuccessDataResult<List<MovieDto>>(_movieDal.GetMoviesByDetails(), "Listelendi");
        }
    }
}
