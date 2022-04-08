using Microsoft.Extensions.DependencyInjection;
using PomeloSoftCase.Infrastructure.Abstract;
using PomeloSoftCase.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEncryptionManager, EncryptionManager>();
            services.AddScoped<IFileControl, FileControl>();
        }
    }
}
