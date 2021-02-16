using System;
using System.Collections.Generic;
using System.Text;

namespace FlickClick.BL
{
    public class DBConstructors
    {
        public DBMovies makeMovies()
        {
            return new DBMovies();
        }
        public DBDirectors makeDirectors()
        {
            return new DBDirectors();
        }
    }
}
