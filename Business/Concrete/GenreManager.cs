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
    public class GenreManager : BaseManager<Genre>, IGenreService
    {
        private IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal) : base(genreDal)
        {
            _genreDal = genreDal;
        }
    }
}
