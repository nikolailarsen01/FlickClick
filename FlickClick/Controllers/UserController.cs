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
            UserModel um = new UserModel();
            int userID = (int)HttpContext.Session.GetInt32("userID");

            string query = "SELECT users.userID, firstnames.firstName, lastnames.lastName, emailusers.email, citycodes.postalCode, streetnames.streetName, addressjunction.houseNumber, phoneNumber, profilePicPath, userSince FROM `users` INNER JOIN firstnames ON users.firstNameID = firstnames.firstNameID INNER JOIN lastnames ON users.lastNameID = lastnames.lastNameID INNER JOIN addressjunction ON users.addressID = addressjunction.ID INNER JOIN citycodes ON addressjunction.cityID = citycodes.cityID INNER JOIN streetnames ON addressjunction.streetID = streetnames.streetID INNER JOIN emailusers ON users.userID = emailusers.userID WHERE users.userID='"+userID+"'";
            MySqlCommand cmd = new MySqlCommand(query);
            DataTable dtb = db.SqlSelectQuery(cmd);
            for (int i = 0; i < dtb.Rows.Count; i++)
            {

                um.userID = (int)dtb.Rows[i]["userID"];
                um.firstName = dtb.Rows[i]["firstName"].ToString();
                um.lastName = dtb.Rows[i]["lastName"].ToString();
                um.email = dtb.Rows[i]["email"].ToString();
                um.postalCode = (int)dtb.Rows[i]["postalCode"];
                um.streetName = dtb.Rows[i]["streetName"].ToString();
                um.houseNumber = dtb.Rows[i]["houseNumber"].ToString();
                um.phoneNumber = Convert.ToInt32(dtb.Rows[i]["phoneNumber"]);
                um.profilePicPath = dtb.Rows[i]["profilePicPath"].ToString();
                um.userSince = (DateTime)dtb.Rows[i]["userSince"];
            }
            return View(um);
        }

        public ActionResult Edit()
        {
            UserModel um = new UserModel();
            int userID = (int)HttpContext.Session.GetInt32("userID");

            string query = "SELECT users.userID, firstnames.firstName, lastnames.lastName, emailusers.email, citycodes.postalCode, streetnames.streetName, addressjunction.houseNumber, phoneNumber, profilePicPath, userSince FROM `users` INNER JOIN firstnames ON users.firstNameID = firstnames.firstNameID INNER JOIN lastnames ON users.lastNameID = lastnames.lastNameID INNER JOIN addressjunction ON users.addressID = addressjunction.ID INNER JOIN citycodes ON addressjunction.cityID = citycodes.cityID INNER JOIN streetnames ON addressjunction.streetID = streetnames.streetID INNER JOIN emailusers ON users.userID = emailusers.userID WHERE users.userID='" + userID + "'";
            MySqlCommand cmd = new MySqlCommand(query);
            DataTable dtb = db.SqlSelectQuery(cmd);
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                um.firstName = dtb.Rows[i]["firstName"].ToString();
                um.lastName = dtb.Rows[i]["lastName"].ToString();
                um.email = dtb.Rows[i]["email"].ToString();
                um.postalCode = (int)dtb.Rows[i]["postalCode"];
                um.streetName = dtb.Rows[i]["streetName"].ToString();
                um.houseNumber = dtb.Rows[i]["houseNumber"].ToString();
                um.phoneNumber = Convert.ToInt32(dtb.Rows[i]["phoneNumber"]);
            }
            return View(um);
        }

        public ActionResult Comments()
        {
            List<CommentModel> data = new List<CommentModel>();
            string query = "SELECT movies.title, comments.text, comments.postDate FROM `commentjunction` INNER JOIN comments ON commentjunction.commentID = comments.commentID INNER JOIN movies ON commentjunction.movieID = movies.movieID WHERE comments.userID='"+ (int)HttpContext.Session.GetInt32("userID") +"'";
            MySqlCommand cmd = new MySqlCommand(query);
            DataTable dtb = db.SqlSelectQuery(cmd);
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                CommentModel cm = new CommentModel();
                cm.username = dtb.Rows[i]["title"].ToString();
                cm.date = DateTime.Parse(dtb.Rows[i]["postDate"].ToString()).ToString("dd-MM-yyyy");
                cm.comment = dtb.Rows[i]["text"].ToString();
                data.Add(cm);
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult EditUpdate()
        {

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
                    return RedirectToAction("Index");
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
        public ActionResult Logout()
        {
            HttpContext.Session.SetString("loginError", "You logged out");
            HttpContext.Session.SetInt32("userID", 0);
            HttpContext.Session.SetString("firstName", "");
            HttpContext.Session.SetInt32("isAdmin", 0);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ValidateRegister(UserCreateModel userCreate)
        {
            HttpContext.Session.SetString("loginError", "null");
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

            var result = dbUser.CheckUserRegister(db, user);

            if(result.Result.Item2 == false )
            {
                HttpContext.Session.SetString("loginError", "The used email is already in use");
                return View();
            }
            else
            {
                user = result.Result.Item1;
                HttpContext.Session.SetInt32("userID", user.userID);
                HttpContext.Session.SetString("firstName", user.firstName);
                HttpContext.Session.SetInt32("isAdmin", 0);
                return Index();
            }
        }

        public ActionResult UserPage()
        {
            return View();
        }
    }
}
