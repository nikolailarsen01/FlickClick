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
    public class NewsController : Controller
    {
        DBConnector db = new DBConnector();
        DBNews dbNews = new DBNews();
        // GET: HomeController
        public ActionResult Index()
        {
            List<NewsModel> newsMods = dbNews.GetAll(db);
            return View(newsMods);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsModel newsMod)
        {
            dbNews.Insert(db, newsMod);
            return RedirectToAction("Index");
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            NewsModel newsMod = dbNews.GetOne(db, id);
            return View(newsMod);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NewsModel newsMod)
        {
            newsMod.ID = id;
            dbNews.Update(db, newsMod);
            return RedirectToAction("Index");
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            NewsModel newsMod = dbNews.GetOne(db, id);
            return View(newsMod);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            dbNews.Delete(db, id);
            return RedirectToAction("Index");
        }
    }
}
