using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Application.Validations.IdentityValidations;
using TheBestWayServerAPI.Domain.Entities;
using TheBestWayServerAPI.Persistence.Contexts;
using TheBestWayServerAPI.Persistence.Repositories.Read;
using TheBestWayServerAPI.Persistence.Repositories.Write;
using TheBestWayServerAPI.Persistence.Services;

namespace TheBestWayServerAPI.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TheBestWayDbContext>();

            services.AddIdentity<User, Role>(identityOptions =>
            {
                identityOptions.Password.RequireNonAlphanumeric = false;
                identityOptions.Password.RequiredLength = 4;
                identityOptions.Password.RequiredUniqueChars = 1;
                identityOptions.Password.RequireUppercase = false;
                identityOptions.Password.RequireLowercase = false;
                identityOptions.Password.RequireDigit = false;
                identityOptions.Password.RequireNonAlphanumeric = false;
                identityOptions.User.RequireUniqueEmail = false;

            }).AddPasswordValidator<CustomPasswordValidator>()
            .AddUserValidator<CustomUserValidator>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<TheBestWayDbContext>();

            services.AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>));
            services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));

            services.AddScoped<IBaseCategoryReadRepository, BaseCategoryReadRepository>();
            services.AddScoped<IBaseCategoryWriteRepository, BaseCategoryWriteRepository>();
            
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();

            services.AddScoped<IPostReadRepository, PostReadRepository>();
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();

            services.AddScoped<IPostDetailReadRepository, PostDetailReadRepository>();
            services.AddScoped<IPostDetailWriteRepository, PostDetailWriteRepository>();

            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();

            services.AddScoped<IQuestionReadRepository, QuestionReadRepository>();
            services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();

            services.AddScoped<IQuestionAnswerReadRepository, QuestionAnswerReadRepository>();
            services.AddScoped<IQuestionAnswerWriteRepository, QuestionAnswerWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

        }
    }
}
