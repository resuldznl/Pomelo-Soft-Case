using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomeloSoftCaseWepApp.Models
{
    public class CreateBlog
    {
        public int userId { get; set; }
        public int categoryId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
