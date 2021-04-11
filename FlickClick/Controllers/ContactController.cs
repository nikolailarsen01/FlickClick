using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickClick.BL;
using FlickClick.Models;

namespace FlickClick.Controllers
{
    public class ContactController : Controller
    {
        DBConnector db = new DBConnector();
        DBContact dbCont = new DBContact();
        DBNewsAndUpcoming naum = new DBNewsAndUpcoming();


        // GET: ContactController
        public ActionResult Index()
        {
            ContactModel cont = new ContactModel();

            NewsAndUpcomingModel nm = naum.NewsAndUpcoming(db);
            ViewBag.NewsAndUpcoming = nm;
            return View(cont);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactModel cont)
        {
            dbCont.Insert(db, cont);
            return RedirectToAction("Index");
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            List<ContactModel> contMods = dbCont.GetAll(db);
            return View(contMods);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
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

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactController/Edit/5
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

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            ContactModel contMod = dbCont.GetOne(db, id);
            return View(contMod);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            dbCont.Delete(db, id);
            return RedirectToAction("Details");
        }
    }
}
