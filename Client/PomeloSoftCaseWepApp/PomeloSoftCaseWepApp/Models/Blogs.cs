using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomeloSoftCaseWepApp.Models
{
    public class Blogs
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int readCount { get; set; }
        public string coverImage { get; set; }
        public DateTime? createDate { get; set; }
        public User user { get; set; }
    }
}
