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
        DBConnector dbc = new DBConnector();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeModel data = new HomeModel();

            List<PreviewMovieModel> recentTrailers = new List<PreviewMovieModel>();
            List<PreviewMovieModel> commentCountTrailers = new List<PreviewMovieModel>();
            List<NewsModel> recentNews = new List<NewsModel>();
            List<PreviewMovieModel> ComingSoonTrailers = new List<PreviewMovieModel>();


            //string query = @"SELECT * FROM movies ORDER BY releaseDate DESC LIMIT 6";
            string query = @"SELECT commentjunction.movieID, movies.movieID as ID, movies.title, movies.picturePath, movies.releaseDate, COUNT(*) FROM commentjunction INNER JOIN movies ON commentjunction.ID = movies.movieID GROUP BY movieID ORDER BY releaseDate DESC LIMIT 6";
            DataTable dtable = dbc.sqlSelectQueryOld(query);
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

            query = @"SELECT commentjunction.movieID, movies.movieID as ID, movies.title, movies.picturePath, movies.releaseDate, COUNT(*) FROM commentjunction INNER JOIN movies ON commentjunction.ID = movies.movieID GROUP BY movieID ORDER BY Count(*) DESC LIMIT 6";
            dtable = dbc.sqlSelectQueryOld(query);
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

            query = @"SELECT * FROM news ORDER BY postDate DESC LIMIT 2";
            dtable = dbc.sqlSelectQueryOld(query);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                NewsModel nw = new NewsModel();
                nw.ID = (int)dtable.Rows[i]["ID"];
                nw.title = dtable.Rows[i]["title"].ToString();
                nw.text = dtable.Rows[i]["text"].ToString();
                nw.postDate = (DateTime)dtable.Rows[i]["postDate"];
                recentNews.Add(nw);
            }

            query = @"SELECT * FROM movies WHERE ComingSoon='1' ORDER BY releaseDate LIMIT 2";
            dtable = dbc.sqlSelectQueryOld(query);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                PreviewMovieModel pmm = new PreviewMovieModel();
                pmm.movieID = (int)dtable.Rows[i]["movieId"];
                pmm.title = dtable.Rows[i]["title"].ToString();
                pmm.releaseDate = (DateTime)dtable.Rows[i]["releaseDate"];
                pmm.description = dtable.Rows[i]["description"].ToString();
                pmm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                ComingSoonTrailers.Add(pmm);
            }


            data.releaseDateSort = recentTrailers;
            data.commentCountSort = commentCountTrailers;
            data.postDateSort = recentNews;
            data.releaseDateComingSoonSort = ComingSoonTrailers;

            return View(data);
        }

        public IActionResult Privacy()
        {
            

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
