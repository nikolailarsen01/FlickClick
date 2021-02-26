using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class HomeModel
    {
        public List<PreviewMovieModel> releaseDateSort { get; set; }
        public List<PreviewMovieModel> commentCountSort { get; set; }
      }
}
