using FlickClick.BL;
using FlickClick.Models;
using Microsoft.AspNetCore.Hosting;
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
        DBUser dbUser;
        public UserController(IWebHostEnvironment env)
        {
            dbUser = new DBUser(env);
        }
        public ActionResult Index() 
        {

            ViewBag.userID = HttpContext.Session.GetInt32("userID");


            return View();
        }

        [HttpPost]
        public ActionResult ValidateLogin()
        {
            HttpContext.Session.SetString("loginError", "null");
            UserModel user = new UserModel();
            string email = HttpContext.Request.Form["email"];
            string password = HttpContext.Request.Form["password"];
            string currentController = HttpContext.Request.Form["controller"];
            string salt = dbUser.GetSalt(db, email, "user");
            if(salt != "empty")
            {
                string hashedPassword = dbUser.HashPassword(password, salt);
                var result = dbUser.CheckUserLogin(db, email, hashedPassword);
                if(result.Item2 == true)
                {
                    user = result.Item1;
                    HttpContext.Session.SetInt32("userID", user.userID);
                    HttpContext.Session.SetString("firstName", user.firstName);
                    HttpContext.Session.SetInt32("isAdmin", 0);
                    return View(user);
                }
                else
                {
                    HttpContext.Session.SetString("loginError", "Could not login");
                    return RedirectToAction("Index", currentController);
                }
            }
            else
            {
                salt = dbUser.GetSalt(db, email, "admin");
                if (salt != "empty")
                {
                    string hashedPassword = dbUser.HashPassword(password, salt);
                    var result = dbUser.CheckAdminLogin(db, email, hashedPassword);
                    if (result.Item2 == true)
                    {

                        HttpContext.Session.SetString("email", result.Item1[0]);
                        HttpContext.Session.SetInt32("adminID", Int32.Parse(result.Item1[1]));
                        HttpContext.Session.SetInt32("isAdmin", 1);
                        return RedirectToAction("Index", "Cms");
                    }
                    else
                    {
                        HttpContext.Session.SetString("loginError", "Could not login");
                        return RedirectToAction("Index", currentController);
                    }
                }
                else
                {
                    HttpContext.Session.SetString("loginError", "Could not login");
                    return RedirectToAction("Index", currentController);
                }
            }
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ValidateRegister(UserCreateModel userCreate)
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
            user.profilePic = userCreate.profilePic;

            dbUser.CheckUserRegisterAsync(db, user);
            return View();
        }

        public ActionResult UserPage()
        {
            return View();
        }
    }
}
