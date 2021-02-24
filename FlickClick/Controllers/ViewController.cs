using FlickClick.BL;
using FlickClick.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
