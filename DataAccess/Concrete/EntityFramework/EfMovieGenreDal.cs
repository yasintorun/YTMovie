using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieGenreDal : EfEntityRepositoryBase<MovieGenre, MovieContext>, IMovieGenreDal
    {
        public void DeleteByMovieId(int movieId)
        {
            using (var context = new MovieContext()) 
            {
                context.MovieGenres.RemoveRange(context.MovieGenres.Where(x => x.MovieId == movieId));
                context.SaveChanges();
            }
        }
    }
}
