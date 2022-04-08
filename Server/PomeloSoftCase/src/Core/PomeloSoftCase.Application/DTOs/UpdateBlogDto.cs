using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Application.DTOs
{
    public class UpdateBlogDto
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public IFormFile file { get; set; }
    }
}
