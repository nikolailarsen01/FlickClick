using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class UserModel
    {
        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int postalCode { get; set; }
        public string streetName { get; set; }
        public string houseNumber { get; set; }
        public string password { get; set; }
        public int phoneNumber { get; set; }
        public string profilePicPath { get; set; }
        public DateTime userSince { get; set; }
    }
}
