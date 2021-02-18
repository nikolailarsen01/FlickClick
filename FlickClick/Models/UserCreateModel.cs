using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.Models
{
    public class UserCreateModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string confirmEmail { get; set; }
        public int postalCode { get; set; }
        public string streetName { get; set; }
        public int houseNumber { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public int phoneNumber { get; set; }
    }
}
