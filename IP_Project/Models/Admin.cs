using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IP_Project.Models
{
    public class Admin
    {
        public int id { get; set; }
        public String name { get; set; }
        public String role { get; set; }
        public String email { get; set; }
        public String password { get; set; }
    }
}