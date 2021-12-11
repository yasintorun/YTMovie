using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal : EfEntityRepositoryBase<Movie, MovieContext>, IMovieDal
    {
        public List<MovieDto> GetMoviesByDetails()
        {
            using (var context = new MovieContext())
            {
                //var r = context.MovieGenres.ToLookup(x => x.MovieId);
                var result = (from m in context.Movies
                              join mg in context.MovieGenres on m.Id equals mg.MovieId
                              join g in context.Genres on mg.GenreId equals g.Id
                              select new
                              {
                                  Id = m.Id,
                                  Movie = m,
                                  genre = g
                              }).ToLookup(x => x.Id).Select(x => new MovieDto()
                              {
                                  Genres = x.Select(x => x.genre).ToList(),
                                  Movie = x.FirstOrDefault(y => y.Movie.Id == y.Id).Movie,
                              });
                             
                return result.ToList();
            }
        }
    }
}
