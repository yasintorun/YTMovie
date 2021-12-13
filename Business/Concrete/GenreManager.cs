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
    public class GenreManager : BaseManager<Genre>, IGenreService
    {
        private IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal) : base(genreDal)
        {
            _genreDal = genreDal;
        }

        public IResult ChangeStatus(int id)
        {
            var genre = this.GetById(id);
            
            if(genre == null || genre.Data == null || !genre.Success)
            {
                return genre;
            }
            
            genre.Data.Status = !genre.Data.Status;
            
            this.Update(genre.Data);
            
            var msg = genre.Data.Status ? "Kategori Aktif Hale Getirildi" : "Kategori Pasif Hale Getirildi";

            return new SuccessResult(msg);
        }
    }
}
