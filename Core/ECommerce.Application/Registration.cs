﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public static class Registration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
           var assembly = Assembly.GetExecutingAssembly();
           services.AddMediatR(x => x.RegisterServicesFromAssembly(assembly));
        }

    }
}
