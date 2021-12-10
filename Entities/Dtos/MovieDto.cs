using Core.Entities.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class MovieDto : BaseDto
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
