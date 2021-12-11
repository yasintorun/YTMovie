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

        public IResult EditWithGenres(AddMovieDto dto)
        {
            var upMovie = dto.Movie;
            upMovie.Id = dto.Id;
            var updateResult = this.Update(upMovie);
            if(updateResult == null || !updateResult.Success)
            {
                return updateResult;
            }

            var genreDeleteResult = _movieGenreService.DeleteByMovie(dto.Id);
            if(genreDeleteResult == null || !genreDeleteResult.Success)
            {
                return updateResult;
            }

            foreach (var genreId in dto.GenreIds)
            {
                _movieGenreService.Add(new MovieGenre()
                {
                    GenreId = genreId,
                    MovieId = dto.Id,
                });
            }

            return updateResult;
        }

        public IDataResult<List<MovieDto>> GetMoviesByDetails()
        {
            try
            {
                var result = _movieDal.GetMoviesByDetails();
                return new SuccessDataResult<List<MovieDto>>(result, "Filmler listelendi");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<MovieDto>>("Hata oluştu: " + ex.Message);
            }
        }

        public IDataResult<MovieDto> GetDetail(int movieId)
        {
            try
            {
                var result = this.GetMoviesByDetails()?.Data?.SingleOrDefault(x => x.Movie.Id == movieId);
                if(result == null)
                {
                    return new ErrorDataResult<MovieDto>("Film bulunamadı");
                }
                return new SuccessDataResult<MovieDto>(result, "Film detayı getirildi");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<MovieDto>("Hata oluştu: " + ex.Message);
            }
        }
    
        public override Result Delete(Movie entity)
        {
            
            _movieGenreService.DeleteByMovie(entity.Id);

            return base.Delete(entity);
        }
    }
}
