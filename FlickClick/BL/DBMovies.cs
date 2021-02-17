using FlickClick.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FlickClick
{
    public class DBMovies
    {
        public MovieModel getMovie(DBConnector db, int id)
        {
            string query = $"SELECT * FROM movies WHERE movieID='{id}'";
            DataTable dtable = db.sqlSelectQuery(query);
            MovieModel mm = new MovieModel();
            mm.movieID = (int)dtable.Rows[0]["movieId"];
            mm.title = dtable.Rows[0]["title"].ToString();
            mm.releaseDate = (DateTime)dtable.Rows[0]["releaseDate"];
            mm.description = dtable.Rows[0]["description"].ToString();
            mm.directorID = (int)dtable.Rows[0]["directorID"];
            mm.duration = dtable.Rows[0]["duration"].ToString();
            mm.postDate = (DateTime)dtable.Rows[0]["postDate"];
            mm.ageRating = (int)dtable.Rows[0]["ageRating"];
            mm.comingSoon = dtable.Rows[0]["comingSoon"].ToString();
            mm.picturePath = dtable.Rows[0]["picturePath"].ToString();
            return mm;
        }
        public List<MovieModel> getMovies(DBConnector db)
        {
            string query = "SELECT * FROM movies";
            List<MovieModel> movies = new List<MovieModel>();
            DataTable dtable = db.sqlSelectQuery(query);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                MovieModel mm = new MovieModel();
                mm.movieID = (int)dtable.Rows[i]["movieId"];
                mm.title = dtable.Rows[i]["title"].ToString();
                mm.releaseDate = (DateTime)dtable.Rows[i]["releaseDate"];
                mm.description = dtable.Rows[i]["description"].ToString();
                mm.directorID = (int)dtable.Rows[i]["directorID"];
                mm.duration = dtable.Rows[i]["duration"].ToString();
                mm.postDate = (DateTime)dtable.Rows[i]["postDate"];
                mm.ageRating = (int)dtable.Rows[i]["ageRating"];
                mm.comingSoon = dtable.Rows[i]["comingSoon"].ToString();
                mm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                movies.Add(mm);
            }
            return movies;
        }
        public void update(DBConnector db, MovieModel movie)
        {
            string query = $"UPDATE movies SET title='{movie.title}', releaseDate='{movie.releaseDate.ToString("yyyy-MM-dd")}', description='{movie.description}', directorID={movie.directorID}" +
                $", duration='{movie.duration}', postDate='{movie.postDate.ToString("yyyy-MM-dd HH:mm:ss")}', ageRating={movie.ageRating}, comingSoon={movie.comingSoon}, picturePath='{movie.picturePath}' " +
                $"WHERE movieID={movie.movieID}";
            db.sqlUpdateOrAddQuery(query);
        }
        public void add(DBConnector db, MovieModel movie)
        {
            string query = "";
        }
    }
}
