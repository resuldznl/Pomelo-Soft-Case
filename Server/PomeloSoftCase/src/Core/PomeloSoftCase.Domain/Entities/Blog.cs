using PomeloSoftCase.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public int? ReadCount { get; set; }
        public string CoverImage { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }

    }
}
