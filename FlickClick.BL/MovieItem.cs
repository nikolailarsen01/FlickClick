using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class MovieItem : IMovieItem
    {
        public int movieID { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string description { get; set; }
        public int directorID { get; set; }
        public string duration { get; set; }
        public DateTime postDate { get; set; }
        public int ageRating { get; set; }
        public string comingSoon { get; set; }
        public string picturePath { get; set; }
    }
}
