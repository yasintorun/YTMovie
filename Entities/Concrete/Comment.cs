using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public string CommentContent { get; set; }
        public int Score { get; set; } = 5;
        public bool Status { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int MovieId { get; set; }
    }
}
