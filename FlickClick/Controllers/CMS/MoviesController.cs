using FlickClick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace FlickClick.Controllers.CMS
{
    public class MoviesController : Controller
    {
        DBConnector db = new DBConnector();
        DBMovies dbMovie = new DBMovies();
        DBDirectors dbDirectors = new DBDirectors();

        // GET: CmsController
        public ActionResult Index()
        {
            return View("~/Views/CMS/Movies/Index.cshtml");
        }

        // GET: CmsController/Details/5
        public ActionResult Details(int id)
        {
            db.makeConnection();
            List<MovieModel> movies = dbMovie.getMovies(db);
            return View("~/Views/CMS/Movies/Details.cshtml", movies);
        }

        // GET: CmsController/Create
        public ActionResult Create()
        {
            return View("~/Views/CMS/Movies/Create.cshtml");
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
                return View("~/Views/CMS/Movies/Create.cshtml");
            }
        }

        // GET: CmsController/Edit/5
        public ActionResult Edit(int id)
        {
            db.makeConnection();
            MovieDirectorModel mdModel = new MovieDirectorModel();
            MovieModel mm = dbMovie.getMovie(db, id);
            mdModel.MovieModel = mm;
            List<DirectorModel> directors = dbDirectors.getDirectors(db);
            mdModel.DirectorsModel = directors;
            return View("~/Views/CMS/Movies/Edit.cshtml", mdModel);
        }

        // POST: CmsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieDirectorModel mdModel, int id)
        {
            /* try
             {
                 return RedirectToAction(nameof(Index));
             }
             catch
             {*/
            //  }
            db.makeConnection();
            mdModel.MovieModel.movieID = id;
            dbMovie.update(db, mdModel.MovieModel);
            return RedirectToAction("Details");
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
