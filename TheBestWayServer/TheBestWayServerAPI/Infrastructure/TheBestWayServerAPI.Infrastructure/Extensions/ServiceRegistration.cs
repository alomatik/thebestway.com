using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.RabbitMQPublishers;
using TheBestWayServerAPI.Application.Abstractions.Security.JWT;
using TheBestWayServerAPI.Infrastructure.Services.RabbitMQPublisher;

namespace TheBestWayServerAPI.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenHandler, TheBestWayServerAPI.Infrastructure.Services.Security.JWT.TokenHandler>();
            services.AddSingleton<IRabbitMQResetPasswordPublisher, RabbitMQResetPasswordPublisher>();
        }
    }
}
