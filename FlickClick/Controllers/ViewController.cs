using FlickClick.BL;
using FlickClick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers
{
    public class ViewController : Controller
    {
        DBConnector db = new DBConnector();
        public IActionResult Movie(int ID)
        {
            DBMovieDetails dbmd = new DBMovieDetails();
            MovieDetailsModel mdm = dbmd.GetMovieDetails(db, ID);

            return View(mdm);
        }

        [HttpPost]
        public string Comment(string comment, int movieID)
        {
            string result = "<div class='movie-comments-section-comment'> " +
                "<div class='movie-comments-section-comment-user-date'>" +
                    "<p>"+HttpContext.Session.GetString("firstName")+"&nbsp;<p class='c-red'>" + DateTime.Now.ToString("dd-MM-yyyy")+"</p> " +
                "</div> " +
                    "<p>"+comment+" " +
                "</div> ";

            string query = "INSERT INTO `comments` (`userID`, `text`, `postDate`) VALUES (@userID,@text, @postDate)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@userID", HttpContext.Session.GetInt32("userID"));
            cmd.Parameters.AddWithValue("@text", comment);
            cmd.Parameters.AddWithValue("@postDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            db.sqlUpdateOrInsertQuery(cmd);

            int commentID = Convert.ToInt32(cmd.LastInsertedId);

            query = "INSERT INTO `commentjunction`(`movieID`, `commentID`) VALUES (@movieID, @commentID)";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@movieID", movieID);
            cmd.Parameters.AddWithValue("@commentID", commentID);

            db.sqlUpdateOrInsertQuery(cmd);


            return result;
        }

    }
}
