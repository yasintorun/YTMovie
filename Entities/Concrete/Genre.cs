using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
