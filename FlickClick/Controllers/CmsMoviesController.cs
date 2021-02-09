using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers
{
    public class CmsMoviesController : Controller
    {
        // GET: CmsMoviesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CmsMoviesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CmsMoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CmsMoviesController/Create
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

        // GET: CmsMoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CmsMoviesController/Edit/5
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

        // GET: CmsMoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CmsMoviesController/Delete/5
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
