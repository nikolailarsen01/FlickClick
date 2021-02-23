using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class PreviewMovieModel
    {
        public int movieID { get; set; }
        public string title { get; set; }
        public string picturePath { get; set; }
        public string description { get; set; } = "";
        public DateTime releaseDate { get; set; }
        public int commentsCount { get; set; }

    }
}
