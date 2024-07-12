using ECommerce.Application.Automapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Mapper
{
    public static class Registration
    {
        public static void MapperServices(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, ECommerce.Mapper.Automapper.Mapper>();
        }

    }
}
