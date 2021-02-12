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
    public class CmsController : Controller
    {
        DBConnector db = new DBConnector();
        
        // GET: CmsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CmsController/Details/5
        public ActionResult Details(int id)
        {
            List<MovieModel> recentTrailers = new List<MovieModel>();

            string query = @"SELECT * FROM movies ORDER BY releaseDate";
            db.makeConnection();
            DataTable dtable = db.sqlSelectQuery(query);
            db.closeConnection();

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
                recentTrailers.Add(mm);
            }

            return View(recentTrailers);
        }
        // POST EditMovie
        [HttpPost]
        public ActionResult EditMovie()
        {
            int movieid = Int16.Parse(HttpContext.Request.Form["movieEditID"].ToString());
            List<MovieModel> recentTrailers = new List<MovieModel>();
            string query = @"SELECT * FROM movies WHERE movieID='" + movieid + "'";
            db.makeConnection();
            DataTable dtable = db.sqlSelectQuery(query);
            db.closeConnection();

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
                recentTrailers.Add(mm);
            }

            return View(recentTrailers);
        }

        // GET: CmsController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: CmsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CmsController/Edit/5
      /*  public ActionResult Edit(int id)
        {
            return View();
        }*/

        // POST: CmsController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            /* try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {*/
            //  }
            string actionContext = HttpContext.Request.Form["submit"].ToString();

            if (actionContext == "Rediger")
            {
                int movieid = Int16.Parse(HttpContext.Request.Form["movieEditID"].ToString());
                string query = @"SELECT * FROM movies WHERE movieID='" + movieid + "'";
                db.makeConnection();
                DataTable dtable = db.sqlSelectQuery(query);
                db.closeConnection();
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
                return View(mm);
            }
            else if (actionContext == "Save")
            {
                return View();
            }
            else return View();
            
          
        }

        // GET: CmsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CmsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
