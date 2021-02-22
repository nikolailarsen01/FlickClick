using FlickClick.BL;
using FlickClick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FlickClick.Controllers.CMS
{
    public class WritersController : Controller
    {
        DBConnector db = new DBConnector();
        DBWriters dbWriters = new DBWriters();

        // GET: WritersController
        public ActionResult Index()
        {
            List<WriterModel> writerMods = dbWriters.GetAll(db);
            return View(writerMods);
        }

        // GET: WritersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WritersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WritersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WriterModel writerMod)
        {
            dbWriters.Insert(db, writerMod);
            return RedirectToAction("Index");
        }

        // GET: WritersController/Edit/5
        public ActionResult Edit(int id)
        {
            WriterModel writerMod = dbWriters.GetOne(db, id);
            return View(writerMod);
        }

        // POST: WritersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WriterModel writerMod)
        {
            writerMod.writerID = id;
            dbWriters.Update(db, writerMod);
            return RedirectToAction("Index");
        }

        // GET: WritersController/Delete/5
        public ActionResult Delete(int id)
        {
            WriterModel writerMod = dbWriters.GetOne(db, id);
            return View(writerMod);
        }

        // POST: WritersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            dbWriters.Delete(db, id);
            return RedirectToAction("Index");
        }
    }
}
