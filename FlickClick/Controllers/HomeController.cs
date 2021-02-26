using FlickClick.BL;
using FlickClick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DBConnector db = new DBConnector();
        DBNewsAndUpcoming naum = new DBNewsAndUpcoming();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeModel data = new HomeModel();

            List<PreviewMovieModel> recentTrailers = new List<PreviewMovieModel>();
            List<PreviewMovieModel> commentCountTrailers = new List<PreviewMovieModel>();

            
            string query = @"SELECT commentjunction.movieID, movies.movieID as ID, movies.title, movies.picturePath, movies.releaseDate, COUNT(*) FROM commentjunction INNER JOIN movies ON commentjunction.movieID = movies.movieID GROUP BY movies.movieID ORDER BY releaseDate DESC LIMIT 6";
            DataTable dtable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                PreviewMovieModel pmm = new PreviewMovieModel();
                pmm.movieID = (int)dtable.Rows[i]["ID"];
                pmm.title = dtable.Rows[i]["title"].ToString();
                pmm.releaseDate = (DateTime)dtable.Rows[i]["releaseDate"];
                pmm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                pmm.commentsCount = Convert.ToInt32(dtable.Rows[i]["Count(*)"]);
                recentTrailers.Add(pmm);
            }

            query = @"SELECT commentjunction.movieID, movies.movieID as ID, movies.title, movies.picturePath, movies.releaseDate, COUNT(*) FROM commentjunction INNER JOIN movies ON commentjunction.movieID = movies.movieID GROUP BY movies.movieID ORDER BY Count(*) DESC LIMIT 6";
            dtable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                PreviewMovieModel pmm = new PreviewMovieModel();
                pmm.movieID = (int)dtable.Rows[i]["ID"];
                pmm.title = dtable.Rows[i]["title"].ToString();
                pmm.releaseDate = (DateTime)dtable.Rows[i]["releaseDate"];
                pmm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                pmm.commentsCount = Convert.ToInt32(dtable.Rows[i]["Count(*)"]);
                commentCountTrailers.Add(pmm);
            }


            data.releaseDateSort = recentTrailers;
            data.commentCountSort = commentCountTrailers;

            NewsAndUpcomingModel nm = naum.NewsAndUpcoming(db);
            ViewBag.NewsAndUpcoming = nm;

            return View(data);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
