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
using System.IO;

namespace FlickClick.Controllers
{
    public class UserController : Controller
    {
        DBConnector db = new DBConnector();
        DBUser dbUser;

        private IHostingEnvironment Environment;

        public UserController(IWebHostEnvironment env, IHostingEnvironment _environment)
        {
            dbUser = new DBUser(env);
            Environment = _environment;
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
            int userID = (int)HttpContext.Session.GetInt32("userID");
            UserModel user = new UserModel();
            user.firstName = HttpContext.Request.Form["firstName"];
            user.lastName = HttpContext.Request.Form["lastName"];
            user.email = HttpContext.Request.Form["email"];
            user.postalCode = Int32.Parse(HttpContext.Request.Form["postalCode"]);
            user.streetName = HttpContext.Request.Form["streetName"];
            user.houseNumber = HttpContext.Request.Form["houseNumber"];
            user.password = HttpContext.Request.Form["password"];
            user.phoneNumber = Int32.Parse(HttpContext.Request.Form["phoneNumber"]);

            int firstNameID = 0;
            int lastNameID = 0;
            int addressID = 0;
            int emailID = 0;

            string query = "SELECT * FROM users WHERE userID='"+ userID + "'";
            MySqlCommand cmd = new MySqlCommand(query);
            DataTable dtb = db.SqlSelectQuery(cmd);
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                firstNameID = (int)dtb.Rows[i]["firstNameID"];
                lastNameID = (int)dtb.Rows[i]["lastNameID"];
                addressID = (int)dtb.Rows[i]["addressID"];
            }


            //firstName
            int newFirstNameID = 0;
            query = "SELECT * FROM firstnames WHERE firstName='"+ user.firstName +"'";
            cmd = new MySqlCommand(query);
            dtb = db.SqlSelectQuery(cmd);
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    newFirstNameID = (int)dtb.Rows[i]["firstNameID"];
                }
            }
            else
            {
                query = "INSERT INTO firstnames (`firstName`) VALUES ('"+user.firstName+"')";
                cmd = new MySqlCommand(query);
                db.sqlUpdateOrInsertQuery(cmd);
                newFirstNameID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //lastName
            int newLastNameID = 0;
            query = "SELECT * FROM lastnames WHERE lastName='" + user.lastName + "'";
            cmd = new MySqlCommand(query);
            dtb = db.SqlSelectQuery(cmd);
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    newLastNameID = (int)dtb.Rows[i]["lastNameID"];
                }
            }
            else
            {
                query = "INSERT INTO lastnames (`lastName`) VALUES ('" + user.lastName + "')";
                cmd = new MySqlCommand(query);
                db.sqlUpdateOrInsertQuery(cmd);
                newLastNameID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //cityID
            int newCityID = 0;
            query = "SELECT * FROM citycodes WHERE postalCode='" + user.postalCode + "'";
            cmd = new MySqlCommand(query);
            dtb = db.SqlSelectQuery(cmd);
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    newCityID = (int)dtb.Rows[i]["cityID"];
                }
            }
            else
            {
                query = "INSERT INTO citycodes (`postalCode`) VALUES ('" + user.postalCode + "')";
                cmd = new MySqlCommand(query);
                db.sqlUpdateOrInsertQuery(cmd);
                newCityID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //streetID
            int newStreetID = 0;
            query = "SELECT * FROM streetnames WHERE streetName='" + user.streetName + "'";
            cmd = new MySqlCommand(query);
            dtb = db.SqlSelectQuery(cmd);
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    newStreetID = (int)dtb.Rows[i]["streetID"];
                }
            }
            else
            {
                query = "INSERT INTO streetnames (`streetName`) VALUES ('" + user.streetName + "')";
                cmd = new MySqlCommand(query);
                db.sqlUpdateOrInsertQuery(cmd);
                newStreetID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //addressID
            int newAddressID = 0;
            query = "SELECT * FROM addressjunction WHERE cityID='" + newCityID + "' AND streetID='"+ newStreetID +"' AND houseNumber='"+ user.houseNumber +"'";
            cmd = new MySqlCommand(query);
            dtb = db.SqlSelectQuery(cmd);
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    newAddressID = (int)dtb.Rows[i]["ID"];
                }
            }
            else
            {
                query = "INSERT INTO addressjunction (cityID, streetID, houseNumber) VALUES ('" + newCityID + "','" + newStreetID + "','" + user.houseNumber + "')";
                cmd = new MySqlCommand(query);
                db.sqlUpdateOrInsertQuery(cmd);
                newAddressID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //email
            query = "UPDATE emailusers SET email='"+user.email+"' WHERE userID='"+userID+"'";
            cmd = new MySqlCommand(query);
            db.sqlUpdateOrInsertQuery(cmd);

            //user
            query = "UPDATE users SET firstNameID='"+newFirstNameID+ "',lastNameID='" + newLastNameID + "', addressID='" + newAddressID + "', phoneNumber='"+user.phoneNumber+"' WHERE userID='"+userID+"'";
            cmd = new MySqlCommand(query);
            db.sqlUpdateOrInsertQuery(cmd);

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

            if(result.Item2 == false )
            {
                HttpContext.Session.SetString("loginError", "The used email is already in use");
                return View();
            }
            else
            {
                user = result.Item1;
                HttpContext.Session.SetInt32("userID", user.userID);
                HttpContext.Session.SetString("firstName", user.firstName);
                HttpContext.Session.SetInt32("isAdmin", 0);
                return Index();
            }
        }

        [HttpPost]
        public IActionResult Index(List<IFormFile> postedFiles)
        {
            UserModel um = new UserModel();
            int userID = (int)HttpContext.Session.GetInt32("userID");

            string query = "SELECT users.userID, firstnames.firstName, lastnames.lastName, emailusers.email, citycodes.postalCode, streetnames.streetName, addressjunction.houseNumber, phoneNumber, profilePicPath, userSince FROM `users` INNER JOIN firstnames ON users.firstNameID = firstnames.firstNameID INNER JOIN lastnames ON users.lastNameID = lastnames.lastNameID INNER JOIN addressjunction ON users.addressID = addressjunction.ID INNER JOIN citycodes ON addressjunction.cityID = citycodes.cityID INNER JOIN streetnames ON addressjunction.streetID = streetnames.streetID INNER JOIN emailusers ON users.userID = emailusers.userID WHERE users.userID='" + userID + "'";
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

            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "assets/profile-pictures");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, "pictureforuser" + userID + ".png"), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }

                query = "UPDATE users SET profilePicPath='assets/profile-pictures/" + "pictureforuser" + userID + ".png" +"' WHERE userID='" +userID+"' ";
                cmd = new MySqlCommand(query);
                db.sqlUpdateOrInsertQuery(cmd);
            }

            return View(um);
        }
    }
}
