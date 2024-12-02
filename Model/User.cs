using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod08.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Course { get; set; } // Add this property
        //public string FullNames => $"{Firstname} {Lastname}";
    }
    //public class LoginResponse
    //{
    //    public string Message { get; set; }
    //}
}

