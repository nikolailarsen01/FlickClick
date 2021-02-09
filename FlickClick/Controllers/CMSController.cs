using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers
{
    public class CMSController : Controller
    {
        // GET: CMSController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CMSController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CMSController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMSController/Create
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

        // GET: CMSController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CMSController/Edit/5
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

        // GET: CMSController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CMSController/Delete/5
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
