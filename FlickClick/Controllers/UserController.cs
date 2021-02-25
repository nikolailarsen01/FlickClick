using FlickClick.BL;
using FlickClick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers
{
    public class UserController : Controller
    {
        DBConnector db = new DBConnector();
        DBUser dbUser = new DBUser();
        public ActionResult Index() 
        {

            ViewBag.userID = HttpContext.Session.GetInt32("userID");


            return View();
        }

        [HttpPost]
        public ActionResult ValidateLogin()
        {
            UserModel user = new UserModel();
            string email = HttpContext.Request.Form["email"];
            string password = HttpContext.Request.Form["password"];
            string salt = dbUser.GetSalt(db, email);
            if(salt != "empty")
            {
                string hashedPassword = dbUser.HashPassword(password, salt);
                var result = dbUser.CheckUserLogin(db, email, hashedPassword);
                if(result.Item2 == true)
                {
                    user = result.Item1;
                    HttpContext.Session.SetInt32("userID", user.userID);
                    HttpContext.Session.SetString("firstName", user.firstName);
                    ViewBag.userID = HttpContext.Session.GetInt32("userID");
                    return View(user);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ValidateRegister()
        {
            UserModel user = new UserModel();
            user.firstName = HttpContext.Request.Form["firstName"];
            user.lastName = HttpContext.Request.Form["lastName"];
            user.email = HttpContext.Request.Form["email"];
            user.postalCode = Int32.Parse(HttpContext.Request.Form["postalCode"]);
            user.streetName = HttpContext.Request.Form["streetName"];
            user.houseNumber = HttpContext.Request.Form["houseNumber"];
            user.password = HttpContext.Request.Form["password"];
            user.phoneNumber = Int32.Parse(HttpContext.Request.Form["phoneNumber"]);

            dbUser.CheckUserRegister(db, user);
            return View();
        }

        public ActionResult UserPage()
        {
            return View();
        }
    }
}
