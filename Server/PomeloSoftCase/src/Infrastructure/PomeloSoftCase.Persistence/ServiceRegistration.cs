using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PomeloSoftCase.Application.Interfaces.Repositories;
using PomeloSoftCase.Application.Interfaces.Services;
using PomeloSoftCase.Persistence.Concrete.Repositories;
using PomeloSoftCase.Persistence.Concrete.Services;
using PomeloSoftCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            var confService = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(confService.GetConnectionString("BlogDbConnectionString")));
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
