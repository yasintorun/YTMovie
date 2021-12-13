using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CommentDto : BaseDto
    {
        public Comment Comment{ get; set; }
        public Movie Movie{ get; set; }
    }
}
