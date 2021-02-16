using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class MovieDirectorModel
    {
        public MovieModel MovieModel { get; set; }
        public List<DirectorModel> DirectorsModel { get; set; }
    }
}
