using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class MovieDetailsModel
    {
        public string title { get; set; }
        public int ageRating { get; set; }
        public string duration { get; set; }
        public List<string> genres { get; set; }
        public string releaseDate { get; set; }
        public string picturePath { get; set; }
        public string trailerPath { get; set; }
        public string director { get; set; }
        public List<string> writers { get; set; }
        public List<string> stars { get; set; }
        public string description { get; set; }
        public int commentCount { get; set; }
        public List<CommentModel> comments { get; set; }

    }
}
