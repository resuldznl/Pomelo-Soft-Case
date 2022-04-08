using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomeloSoftCaseWepApp.Models
{
    public class UpdateBlog
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
