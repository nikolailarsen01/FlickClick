using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string username { get; set; }
        public string date { get; set; }
        public DateTime dateTime { get; set; }
        public string comment { get; set; }
        public int movieID { get; set; }

    }
}
