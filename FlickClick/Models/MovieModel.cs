using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace FlickClick.Models
{
    public class MovieModel
    {
        public int movieID { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string description { get; set; }
        public int directorID { get; set; }
        public string duration { get; set; }
        public DateTime postDate { get; set; }
        public int ageRating { get; set; }
        public string comingSoon { get; set; }
        public string picturePath { get; set; }
        public IFormFile pictureImage { get; set; }
        public string trailerPath { get; set; }
    }
}
