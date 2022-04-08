using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Application.DTOs
{
    public class GetBlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReadCount { get; set; }
        public string CoverImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public GetUserDto User { get; set; }

    }
}
