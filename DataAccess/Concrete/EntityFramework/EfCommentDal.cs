using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, MovieContext>, ICommentDal
    {
        public List<CommentDto> GetAllDto()
        {
            using (var context = new MovieContext())
            {
                var result = from c in context.Comments
                             join m in context.Movies on c.MovieId equals m.Id
                             select new CommentDto
                             {
                                 Comment = c,
                                 Movie = m
                             };
                return result.ToList();                    
            }
        }

        public List<Comment> GetByMovieId(int movieId)
        {
            using(var context = new MovieContext())
            {
                return context.Comments.Where(x => x.MovieId == movieId && x.Status == true).ToList();
            }
        }
    }
}
