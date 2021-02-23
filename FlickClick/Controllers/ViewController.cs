using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Movie(int ID)
        {



            return View();
        }
    }
}
