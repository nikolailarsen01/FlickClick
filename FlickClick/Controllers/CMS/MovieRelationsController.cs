using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickClick.BL;
using FlickClick.Models;


namespace FlickClick.Controllers.CMS
{
    public class MovieRelationsController : Controller
    {
        DBConnector db = new DBConnector();
        DBMovies dbMovie = new DBMovies();
        DBGenres dbGenre = new DBGenres();
        DBStars dbStars = new DBStars();
        DBWriters dbWriters = new DBWriters();
        DBMovieRelations dbMovRls = new DBMovieRelations();

        // GET: MovieRelationsController
        public ActionResult Index()
        {
            List<MovieModel> movies = dbMovie.getMovies(db);
            return View(movies);
        }

        // GET: MovieRelationsController/Details/5
        public ActionResult Details(int id)
        {
            MovieRelationModel model = new MovieRelationModel();
            model.genreJunction = dbMovRls.GetIDs(db, id, "genre");
            model.genres = dbGenre.GetAll(db);
            model.starJunction = dbMovRls.GetIDs(db, id, "star");
            model.stars = dbStars.GetAll(db);
            model.writerJunction = dbMovRls.GetIDs(db, id, "writer");
            model.writers = dbWriters.GetAll(db);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(MovieRelationModel model, int id)
        {
            string actionContext = HttpContext.Request.Form["submit"].ToString();
            List<string> cases = new List<string> { "Add genre", "Add star", "Add writer", "Remove genre", "Remove star", "Remove writer" };
            switch (cases.IndexOf(actionContext))
            {
                case 0:
                    dbMovRls.Save(db, model.selectedGenreID, id, "genrejunction", "genreID");
                    break;
                case 1:
                    dbMovRls.Save(db, model.selectedStarID, id, "starjunction", "starID");
                    break;
                case 2:
                    dbMovRls.Save(db, model.selectedWriterID, id, "writerjunction", "writerID");
                    break;
                case 3:
                    dbMovRls.Delete(db, model.selectedGenreID, id, "genrejunction", "genreID");
                    break;
                case 4:
                    dbMovRls.Delete(db, model.selectedStarID, id, "starjunction", "starID");
                    break;
                case 5:
                    dbMovRls.Delete(db, model.selectedWriterID, id, "writerjunction", "writerID");
                    break;
            }
            model.genreJunction = dbMovRls.GetIDs(db, id, "genre");
            model.genres = dbGenre.GetAll(db);
            model.starJunction = dbMovRls.GetIDs(db, id, "star");
            model.stars = dbStars.GetAll(db);
            model.writerJunction = dbMovRls.GetIDs(db, id, "writer");
            model.writers = dbWriters.GetAll(db);
            return View(model);
        }
        // GET: MovieRelationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieRelationsController/Create
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

        // GET: MovieRelationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieRelationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MovieRelationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieRelationsController/Delete/5
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
