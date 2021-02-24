using FlickClick.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class DBMovieDetails
    {
        public MovieDetailsModel GetMovieDetails(DBConnector db, int movieID)
        {
            MovieDetailsModel mdm = new MovieDetailsModel();

            string query = "SELECT *, directors.firstName, directors.lastName FROM movies INNER JOIN directors ON movies.directorID = directors.directorID  WHERE movieID='"+movieID+"'";
            DataTable dt = db.sqlSelectQueryOld(query);
            mdm.title = dt.Rows[0]["title"].ToString();
            mdm.ageRating = (int)dt.Rows[0]["ageRating"];
            mdm.duration = DateTime.Parse(dt.Rows[0]["duration"].ToString()).ToString("hh:mm");
            mdm.releaseDate = DateTime.Parse(dt.Rows[0]["releaseDate"].ToString()).ToString("dd-MM-yyyy");
            mdm.picturePath = dt.Rows[0]["picturePath"].ToString();
            mdm.trailerPath = dt.Rows[0]["trailerPath"].ToString();
            mdm.description = dt.Rows[0]["description"].ToString();
            mdm.director = dt.Rows[0]["firstName"].ToString() + " " + dt.Rows[0]["lastName"].ToString();

            query = "SELECT comments.userID, users.firstNameID, firstnames.firstName, comments.text, comments.postDate FROM `commentjunction` " +
                "INNER JOIN comments ON commentjunction.commentID = comments.commentID " +
                "INNER JOIN users ON comments.userID = users.userID " +
                "INNER JOIN firstnames ON users.firstNameID = firstnames.firstNameID " +
                "WHERE movieID = '"+movieID+"'";
            dt = db.sqlSelectQueryOld(query);
            mdm.commentCount = dt.Rows.Count;
            mdm.comments = new List<CommentModel>();
            for (int i = 0; i < mdm.commentCount; i++)
            {
                CommentModel cm = new CommentModel();
                cm.username = dt.Rows[i]["firstName"].ToString();
                cm.comment = dt.Rows[i]["text"].ToString();
                cm.date = DateTime.Parse(dt.Rows[i]["postDate"].ToString()).ToString("dd-MM-yyyy");
                mdm.comments.Add(cm);
            }

            query = "SELECT genres.genreName FROM `genrejunction` INNER JOIN genres ON genrejunction.genreID = genres.genreID WHERE movieID = '"+movieID+"'";
            dt = db.sqlSelectQueryOld(query);
            mdm.genres = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mdm.genres.Add(dt.Rows[i]["genreName"].ToString());
            }

            query = "SELECT writers.firstName, writers.lastName FROM `writerjunction` INNER JOIN writers ON writerjunction.writerID = writers.writerID WHERE movieID = '" + movieID + "'";
            dt = db.sqlSelectQueryOld(query);
            mdm.writers = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mdm.writers.Add(dt.Rows[i]["firstName"].ToString() + " " + dt.Rows[i]["lastName"].ToString());
            }

            query = "SELECT stars.firstName, stars.lastName FROM `starjunction` INNER JOIN stars ON starjunction.starID = stars.starID WHERE movieID='" + movieID + "'";
            dt = db.sqlSelectQueryOld(query);
            mdm.stars = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                mdm.stars.Add(dt.Rows[i]["firstName"].ToString() + " " + dt.Rows[i]["lastName"].ToString());
            }

            return mdm;
        }
    }
}
