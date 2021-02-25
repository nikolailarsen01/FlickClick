using FlickClick.Models;
using MySql.Data.MySqlClient;
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
            DataTable dtable = db.sqlSelectQueryOld(query);
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
            DataTable dtable = db.sqlSelectQueryOld(query);
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
            string query = "UPDATE `movies` SET title=@title, releaseDate=@releaseDate, description=@description, directorID=@directorID, duration=@duration, postDate=@postDate, comingSoon=@comingSoon, picturePath=@picturePath WHERE movieID=@movieID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@title", movie.title);
            cmd.Parameters.AddWithValue("@releaseDate", movie.releaseDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@description", movie.description);
            cmd.Parameters.AddWithValue("@directorID", movie.directorID);
            cmd.Parameters.AddWithValue("@duration", movie.duration);
            cmd.Parameters.AddWithValue("@postDate", movie.postDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@ageRating", movie.ageRating);
            cmd.Parameters.AddWithValue("@comingSoon", movie.comingSoon);
            cmd.Parameters.AddWithValue("@picturePath", movie.picturePath);
            cmd.Parameters.AddWithValue("@movieID", movie.movieID);
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void add(DBConnector db, MovieModel movie)
        {
            movie.postDate = DateTime.Now;
            string query = "INSERT INTO `movies` (`title`, `releaseDate`, `description`, `directorID`, `duration`, `postDate`, `ageRating`, `comingSoon`, `picturePath`) " +
                "VALUES (@title, @releaseDate, @description, @directorID, @duration, @postDate, @ageRating, @comingSoon, @picturePath)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@title", movie.title);
            cmd.Parameters.AddWithValue("@releaseDate", movie.releaseDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@description", movie.description);
            cmd.Parameters.AddWithValue("@directorID", movie.directorID);
            cmd.Parameters.AddWithValue("@duration", movie.duration);
            cmd.Parameters.AddWithValue("@postDate", movie.postDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@ageRating", movie.ageRating);
            cmd.Parameters.AddWithValue("@comingSoon", movie.comingSoon);
            cmd.Parameters.AddWithValue("@picturePath", movie.picturePath);
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public  void delete(DBConnector db, int id)
        {
            string query = "DELETE FROM `movies` WHERE movieID=@movieID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@movieID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}
