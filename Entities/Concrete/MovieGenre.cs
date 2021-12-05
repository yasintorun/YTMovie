using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class MovieGenre : BaseEntity
    {
        public int MovieId { get; set; }

        public int GenreId { get; set; }
    }
}
