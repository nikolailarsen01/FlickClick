using FlickClick.BL;
using FlickClick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers
{
    public class ViewController : Controller
    {
        DBConnector db = new DBConnector();
        DBNewsAndUpcoming naum = new DBNewsAndUpcoming();

        public IActionResult Movie(int ID)
        {
            DBMovieDetails dbmd = new DBMovieDetails();
            MovieDetailsModel mdm = dbmd.GetMovieDetails(db, ID);

            NewsAndUpcomingModel nm = naum.NewsAndUpcoming(db);
            ViewBag.NewsAndUpcoming = nm;

            return View(mdm);
        }

        [HttpGet]
        public IActionResult Movies(string filter)
        {
            List<PreviewMovieModel> data = new List<PreviewMovieModel>();

            if (filter == "lastestTrailers")
            {
                string query = "SELECT `movieID`, `title`, `picturePath`, `releaseDate` FROM `movies` ORDER BY releaseDate DESC";
                MySqlCommand cmd = new MySqlCommand(query);
                DataTable dtable = db.SqlSelectQuery(cmd);
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    PreviewMovieModel pmm = new PreviewMovieModel();
                    pmm.movieID = (int)dtable.Rows[i]["movieID"];
                    pmm.title = dtable.Rows[i]["title"].ToString();
                    pmm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                    data.Add(pmm);
                }
                ViewBag.Filter = "Latests Trailers";

            }

            if (filter == "mostCommented")
            {
                string query = "SELECT commentjunction.movieID, movies.movieID as ID, movies.title, movies.picturePath, movies.releaseDate, COUNT(*) FROM commentjunction INNER JOIN movies ON commentjunction.movieID = movies.movieID GROUP BY movies.movieID ORDER BY Count(*) DESC";
                MySqlCommand cmd = new MySqlCommand(query);
                DataTable dtable = db.SqlSelectQuery(cmd);
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    PreviewMovieModel pmm = new PreviewMovieModel();
                    pmm.movieID = (int)dtable.Rows[i]["movieID"];
                    pmm.title = dtable.Rows[i]["title"].ToString();
                    pmm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                    data.Add(pmm);
                }
                ViewBag.Filter = "Most Commented";
            }

            NewsAndUpcomingModel nm = naum.NewsAndUpcoming(db);
            ViewBag.NewsAndUpcoming = nm;
            return View(data);
        }

        [HttpGet]
        public IActionResult searchMovies(string search)
        {
            List<PreviewMovieModel> data = new List<PreviewMovieModel>();
            if (search != "")
            {
                string query = "SELECT `movieID`, `title`, `picturePath` FROM `movies` WHERE title LIKE '%"+search+"%'";
                MySqlCommand cmd = new MySqlCommand(query);
                DataTable dtable = db.SqlSelectQuery(cmd);
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    PreviewMovieModel pmm = new PreviewMovieModel();
                    pmm.movieID = (int)dtable.Rows[i]["movieID"];
                    pmm.title = dtable.Rows[i]["title"].ToString();
                    pmm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                    data.Add(pmm);
                }
            }
            else if(search == null)
            {
                string query = "SELECT `movieID`, `title`, `picturePath` FROM `movies`";
                MySqlCommand cmd = new MySqlCommand(query);
                DataTable dtable = db.SqlSelectQuery(cmd);
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    PreviewMovieModel pmm = new PreviewMovieModel();
                    pmm.movieID = (int)dtable.Rows[i]["movieID"];
                    pmm.title = dtable.Rows[i]["title"].ToString();
                    pmm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                    data.Add(pmm);
                }
            }

            NewsAndUpcomingModel nm = naum.NewsAndUpcoming(db);
            ViewBag.NewsAndUpcoming = nm;
            if (search == null)
            {
                ViewBag.Filter = "All Movies";
            }
            else
            {
                ViewBag.Filter = "'" + search + "' Searched.";
            }

            return View(data);
        }

        public IActionResult News()
        {
            List<NewsModel> data = new List<NewsModel>();

            string query = "SELECT `ID`, `title`, `text`, `postDate` FROM `news` ORDER BY postDate";
            MySqlCommand cmd = new MySqlCommand(query);
            DataTable dtable = db.SqlSelectQuery(cmd);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                NewsModel newsm = new NewsModel();
                newsm.ID = (int)dtable.Rows[i]["ID"];
                newsm.title = dtable.Rows[i]["title"].ToString();
                newsm.text = dtable.Rows[i]["text"].ToString();
                newsm.postDate = DateTime.Parse(dtable.Rows[i]["postDate"].ToString());
                data.Add(newsm);
            }

            NewsAndUpcomingModel nm = naum.NewsAndUpcoming(db);
            ViewBag.NewsAndUpcoming = nm;
            return View(data);
        }

        public IActionResult Article(int ID)
        {
            NewsModel data = new NewsModel();


            string query = "SELECT `ID`, `title`, `text`, `postDate` FROM `news` WHERE ID='"+ID+"'";
            MySqlCommand cmd = new MySqlCommand(query);
            DataTable dtable = db.SqlSelectQuery(cmd);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                NewsModel newsm = new NewsModel();
                data.ID = (int)dtable.Rows[i]["ID"];
                data.title = dtable.Rows[i]["title"].ToString();
                data.text = dtable.Rows[i]["text"].ToString();
                data.postDate = DateTime.Parse(dtable.Rows[i]["postDate"].ToString());
            }

            NewsAndUpcomingModel nm = naum.NewsAndUpcoming(db);
            ViewBag.NewsAndUpcoming = nm;

            return View(data);
        }

        [HttpPost]
        public string Comment(string comment, int movieID)
        {
            string result = "<div class='movie-comments-section-comment'> " +
                "<div class='movie-comments-section-comment-user-date'>" +
                    "<p>"+HttpContext.Session.GetString("firstName")+"&nbsp;<p class='c-red'>" + DateTime.Now.ToString("dd-MM-yyyy")+"</p> " +
                "</div> " +
                    "<p>"+comment+" " +
                "</div> ";

            string query = "INSERT INTO `comments` (`userID`, `text`, `postDate`) VALUES (@userID,@text, @postDate)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@userID", HttpContext.Session.GetInt32("userID"));
            cmd.Parameters.AddWithValue("@text", comment);
            cmd.Parameters.AddWithValue("@postDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            db.sqlUpdateOrInsertQuery(cmd);

            int commentID = Convert.ToInt32(cmd.LastInsertedId);

            query = "INSERT INTO `commentjunction`(`movieID`, `commentID`) VALUES (@movieID, @commentID)";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@movieID", movieID);
            cmd.Parameters.AddWithValue("@commentID", commentID);

            db.sqlUpdateOrInsertQuery(cmd);

            return result;
        }


        public IActionResult NewsAndUpcoming()
        {
            DBNewsAndUpcoming dbnu = new DBNewsAndUpcoming();
            NewsAndUpcomingModel naum = dbnu.NewsAndUpcoming(db);

            return View(naum); ;
        }

    }
}
