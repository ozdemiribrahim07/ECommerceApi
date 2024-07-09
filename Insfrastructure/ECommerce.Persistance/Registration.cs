using ECommerce.Application.Repositories;
using ECommerce.Persistance.Contexts;
using ECommerce.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance
{
    public static class Registration
    {
        public static void RegisterPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommerceContext>(options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }

    }
}
