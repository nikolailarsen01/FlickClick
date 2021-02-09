using FlickClick.Models;
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
        private string connectionString = "server=localhost;userid=root;database=steensoft_dk_flickclick;";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<MovieModel> recentTrailers = new List<MovieModel>();

            string query = @"SELECT * FROM movies ORDER BY releaseDate DESC LIMIT 6";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataAdapter dtb = new MySqlDataAdapter();
            dtb.SelectCommand = cmd;
            DataTable dtable = new DataTable();
            dtb.Fill(dtable);
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
                mm.comingSoon = (int)dtable.Rows[i]["ageRating"];
                mm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                recentTrailers.Add(mm);
            }



            return View(recentTrailers);
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
