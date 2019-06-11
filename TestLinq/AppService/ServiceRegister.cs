using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TestLinq.Contract;

namespace TestLinq.AppService
{
    static class ServiceRegister
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IPostService, PostService>();

            return services;
        }
    }
}
