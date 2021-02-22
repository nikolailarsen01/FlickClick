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
    public class StarsController : Controller
    {
        DBConnector db = new DBConnector();
        DBStars dbStars = new DBStars();

        // GET: StarsController
        public ActionResult Index()
        {
            List<StarModel> starMods = dbStars.GetAll(db);
            return View(starMods);
        }

        // GET: StarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StarModel starMod)
        {
            dbStars.Insert(db, starMod);
            return RedirectToAction("Index");
        }

        // GET: StarsController/Edit/5
        public ActionResult Edit(int id)
        {
            StarModel starMod = dbStars.GetOne(db, id);
            return View(starMod);
        }

        // POST: StarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StarModel starMod)
        {
            starMod.starID = id;
            dbStars.Update(db, starMod);
            return RedirectToAction("Index");
        }

        // GET: StarsController/Delete/5
        public ActionResult Delete(int id)
        {
            StarModel starMod = dbStars.GetOne(db, id);
            return View(starMod);
        }

        // POST: StarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            dbStars.Delete(db, id);
            return RedirectToAction("Index");
        }
    }
}
