using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers
{
    public class CmsController : Controller
    {
        // GET: CmsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CmsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: CmsController/Edit/5
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
