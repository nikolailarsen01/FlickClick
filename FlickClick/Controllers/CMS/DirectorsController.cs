using FlickClick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers.CMS
{
    public class DirectorsController : Controller
    {
        DBConnector db = new DBConnector();
        DBDirectors dbDirectors = new DBDirectors();


        // GET: HomeController
        public ActionResult Index()
        {
            List<DirectorModel> dirMods = dbDirectors.getDirectors(db);
            return View("~/Views/CMS/Directors/Index.cshtml", dirMods);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            List<DirectorModel> dirMods = dbDirectors.getDirectors(db);
            return View("~/Views/CMS/Directors/Details.cshtml", dirMods);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View("~/Views/CMS/Directors/Create.cshtml");
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DirectorModel dirMod)
        {
            dbDirectors.Insert(db, dirMod);
            return RedirectToAction("Index");
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            DirectorModel dirMod = dbDirectors.GetOne(db, id);
            return View("~/Views/CMS/Directors/Edit.cshtml", dirMod);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DirectorModel dirMod, int id)
        {
            dirMod.directorID = id;
            dbDirectors.Update(db, dirMod);
            return RedirectToAction("Index");
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            DirectorModel dirMod = dbDirectors.GetOne(db, id);
            return View("~/Views/CMS/Directors/Delete.cshtml", dirMod);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            dbDirectors.Delete(db, id);
            return RedirectToAction("Index");
        }
    }
}
