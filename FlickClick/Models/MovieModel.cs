﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class MovieModel
    {
        public int movieID { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string description { get; set; }
        public int directorID { get; set; }
        public DateTime duration { get; set; }
        public DateTime postDate { get; set; }
        public int ageRating { get; set; }
        public bool comingSoon { get; set; }
        public string picturePath { get; set; }


    }
}