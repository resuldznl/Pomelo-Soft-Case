using PomeloSoftCase.Application.Interfaces.Repositories;
using PomeloSoftCase.Domain.Entities;
using PomeloSoftCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Persistence.Concrete.Repositories
{
    public class BlogRepository : Repository<Blog> ,IBlogRepository
    {
        public BlogRepository(BlogDbContext context) : base(context)
        {}
    }
}
