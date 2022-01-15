using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; } 
    }
}
