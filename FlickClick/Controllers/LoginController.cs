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
    public class LoginController : Controller
    {
        private string connectionString = "server=localhost;userid=root;database=steensoft_dk_flickclick;";

        public ActionResult Index() 
        {

            ViewBag.userID = HttpContext.Session.GetInt32("userID");


            return View();
        }

        [HttpPost]
        public ActionResult ValidateLogin()
        {
            string email = HttpContext.Request.Form["email"];
            string password = HttpContext.Request.Form["password"];

            string query = "SELECT * FROM emailusers WHERE email='" + email + "'";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataAdapter dtb = new MySqlDataAdapter();
            dtb.SelectCommand = cmd;
            DataTable dtable = new DataTable();
            dtb.Fill(dtable);
            if (dtable.Rows.Count > 0)
            {
                int userID = (int)dtable.Rows[0]["userID"];

                query = "SELECT userID, firstname.firstName FROM users INNER JOIN firstname ON users.userID = firstname.firstNameID WHERE userID=" + userID + " AND Password=" + password;
                cmd = new MySqlCommand(query, connection);
                dtb = new MySqlDataAdapter();
                dtb.SelectCommand = cmd;
                dtable = new DataTable();
                dtb.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    HttpContext.Session.SetInt32("userID", userID);
                    HttpContext.Session.SetString("firstName", dtable.Rows[0]["firstName"].ToString());
                }
            }

            ViewBag.userID = HttpContext.Session.GetInt32("userID");

            connection.Close();

            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ValidateRegister()
        {

            return View();
        }
    }
}
