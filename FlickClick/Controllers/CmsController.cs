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
        DBMovies dbMovie = new DBMovies();

        // GET: CmsController
        public ActionResult Index()
        {
            db.makeConnection();
            return View();
        }

        // GET: CmsController/Details/5
        public ActionResult Details(int id)
        {
            db.makeConnection();
            List<MovieItem> movies = dbMovie.getMovies(db);
            return View(movies);
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
        public ActionResult Edit(int id)
        {
            db.makeConnection();
            MovieItem mm = dbMovie.getMovie(db, id);
            return View(mm);
        }

        // POST: CmsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieItem movie, int id)
        {
            /* try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {*/
            //  }
            db.makeConnection();
            movie.movieID = id;
            dbMovie.updateMovie(db, movie);
            return RedirectToAction("Index");

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
