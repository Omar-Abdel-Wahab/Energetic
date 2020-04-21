using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IP_Project.Models
{
    public class News
    {
        public int id { get; set; }
        public String image { get; set; }
        public DateTime date { get; set; }
        public String title { get; set; }
        public String content { get; set; }

    }
}