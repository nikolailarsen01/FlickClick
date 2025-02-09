﻿using FlickClick.Models;
using FlickClick.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers.CMS
{
    public class CmsUserController : Controller
    {
        DBConnector db = new DBConnector();
        DBUser dbUser = new DBUser();
        // GET: CmsUserController
        public ActionResult Index()
        {
            List<UserModel> userList = dbUser.GetAll(db); 
            return View(userList);
        }

        // GET: CmsUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CmsUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CmsUserController/Create
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

        // GET: CmsUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CmsUserController/Edit/5
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

        // GET: CmsUserController/Delete/5
        public ActionResult Delete(int id)
        {
            UserModel user = dbUser.GetOne(db, id);
            return View(user);
        }

        // POST: CmsUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            dbUser.Delete(db, id);
            return RedirectToAction("Index");
        }
    }
}
