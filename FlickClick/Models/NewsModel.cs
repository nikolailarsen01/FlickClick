using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class NewsModel
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public DateTime postDate { get; set; }
    }
}
