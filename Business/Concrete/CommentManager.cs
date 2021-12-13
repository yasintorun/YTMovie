using Business.Abstract;
using Core.Business;
using Core.Utils.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : BaseManager<Comment>, ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal) : base(commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult ChangeStatus(int id)
        {
            var comment = this.GetById(id);
            if(!comment.Success)
            {
                return comment;
            }
            comment.Data.Status = !comment.Data.Status;

            return this.Update(comment.Data);
        }

        public IDataResult<List<Comment>> GetByMovieId(int movieId)
        {
            try
            {
                var comments = _commentDal.GetByMovieId(movieId);
                return new SuccessDataResult<List<Comment>>(comments, "Filme ait yorumlar getirildi");
            } catch (Exception ex)
            {
                return new ErrorDataResult<List<Comment>>("Hata oluştu: " + ex.Message);
            }
        }

        public IDataResult<List<CommentDto>> GetAllDetails()
        {
            try
            {
                var comments = _commentDal.GetAllDto();
                return new SuccessDataResult<List<CommentDto>>(comments, "Yorumlar detaylı olarak listelendi");
            } catch (Exception e)
            {
                return new ErrorDataResult<List<CommentDto>>("Hata Oluştu: " + e.Message);
            }
        }
    }
}
