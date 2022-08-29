using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Security.JWT;
using TheBestWayServerAPI.Application.Mapping;

namespace TheBestWayServerAPI.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GenericMapProfile));
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
