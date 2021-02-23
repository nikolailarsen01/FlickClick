using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class MovieRelationModel
    {
        public List<GenreModel> genres = new List<GenreModel>();
        public List<StarModel> stars = new List<StarModel>();
        public List<WriterModel> writers = new List<WriterModel>();
        public MovieModel movie = new MovieModel();

        public List<int> genreJunction = new List<int>();
        public int selectedGenreID { get; set; }

        public List<int> starJunction = new List<int>();
        public int selectedStarID { get; set; }

        public List<int> writerJunction = new List<int>();
        public int selectedWriterID { get; set; }

    }
}
