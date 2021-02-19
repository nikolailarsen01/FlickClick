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
    public class GenresController : Controller
    {
        DBConnector db = new DBConnector();
        DBGenres dbGenres = new DBGenres();

        // GET: GenresController
        public ActionResult Index()
        {
            List<GenreModel> genreMod = dbGenres.GetAll(db);
            return View(genreMod);
        }

        // GET: GenresController/Details/5
        public ActionResult Details(int id)
        {
            List<GenreModel> genreMod = dbGenres.GetAll(db);
            return View();
        }

        // GET: GenresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreModel genreMod)
        {
            dbGenres.Insert(db, genreMod);
            return RedirectToAction("Index");
        }

        // GET: GenresController/Edit/5
        public ActionResult Edit(int id)
        {
            GenreModel genreMod = dbGenres.GetOne(db, id);
            return View(genreMod);
        }

        // POST: GenresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GenreModel genreMod, int id)
        {
            genreMod.genreID = id;
            dbGenres.Update(db, genreMod);
            return RedirectToAction("Index");
        }

        // GET: GenresController/Delete/5
        public ActionResult Delete(int id)
        {
            GenreModel genreMod = dbGenres.GetOne(db, id);
            return View(genreMod);
        }

        // POST: GenresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            dbGenres.Delete(db, id);
            return RedirectToAction("Index");
        }
    }
}
