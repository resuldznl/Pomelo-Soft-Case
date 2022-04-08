using PomeloSoftCase.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Blogs = new HashSet<Blog>();
        }
        public string CategoryName { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }

    }
}
