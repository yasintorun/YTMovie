using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double IMDB { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
        public string VideoLink { get; set; }
        public string PosterLink { get; set; }
        public string WallpaperLink { get; set; }
    }
}
