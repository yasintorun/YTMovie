using Core.Entities.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AddMovieDto : BaseDto
    {
        public Movie Movie { get; set; }
        public int[] GenreIds { get; set; }
    }
}
