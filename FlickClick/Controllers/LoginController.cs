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
            string firstName = HttpContext.Request.Form["firstName"];
            string lastName = HttpContext.Request.Form["lastName"];
            string email = HttpContext.Request.Form["email"];
            int postalCode = Int32.Parse(HttpContext.Request.Form["postalCode"]);
            string streetName = HttpContext.Request.Form["streetName"];
            string houseNumber = HttpContext.Request.Form["houseNumber"];
            string password = HttpContext.Request.Form["password"];
            int phoneNumber = Int32.Parse(HttpContext.Request.Form["phoneNumber"]);

            int postalCodeID = 0;
            int streetNameID = 0;
            int adressID = 0;
            //postalCode
            string query = "SELECT * FROM citycodes WHERE PostalCode='"+postalCode+"'";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataAdapter dtb = new MySqlDataAdapter();
            dtb.SelectCommand = cmd;
            DataTable dtable = new DataTable();
            dtb.Fill(dtable);
            if (dtable.Rows.Count > 0)
            {
                postalCodeID = (int)dtable.Rows[0]["cityID"];
            }
            else
            {
                query = "INSERT INTO `citycodes`(`PostalCode`) VALUES ('"+postalCode+"')";
                cmd = new MySqlCommand(query, connection);
                postalCodeID = cmd.ExecuteNonQuery();
            }

            //streetName
            query = "SELECT * FROM streetnames WHERE streetName='" + streetName + "'";
            connection = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(query, connection);
            connection.Open();
            dtb = new MySqlDataAdapter();
            dtb.SelectCommand = cmd;
            dtable = new DataTable();
            dtb.Fill(dtable);
            if (dtable.Rows.Count > 0)
            {
                streetNameID = (int)dtable.Rows[0]["streetID"];
            }
            else
            {
                query = "INSERT INTO `streetnames`(`streetName`) VALUES ('" + streetName + "')";
                cmd = new MySqlCommand(query, connection);
                streetNameID = cmd.ExecuteNonQuery();
            }

            //Adress
            query = "SELECT * FROM addressjunction WHERE cityID='" + postalCodeID + "' AND streetID='" + streetNameID + "' AND houseNumber='" + houseNumber + "'";
            connection = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(query, connection);
            connection.Open();
            dtb = new MySqlDataAdapter();
            dtb.SelectCommand = cmd;
            dtable = new DataTable();
            dtb.Fill(dtable);
            if (dtable.Rows.Count > 0)
            {
                adressID = (int)dtable.Rows[0]["ID"];
            }
            else
            {
                query = "INSERT INTO `addressjunction`(`cityID`, `streetID`, `houseNumber`) VALUES ('"+postalCodeID+ "','" + streetNameID + "','" + houseNumber + "')";
                cmd = new MySqlCommand(query, connection);
                streetNameID = cmd.ExecuteNonQuery();
            }




            return View();
        }
    }
}
