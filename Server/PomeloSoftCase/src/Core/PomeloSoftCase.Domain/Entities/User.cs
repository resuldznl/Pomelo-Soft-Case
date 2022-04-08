using PomeloSoftCase.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }

    }
}
