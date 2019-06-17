﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TestLinq.AppService;

namespace TestLinq
{
    class Startup
    {
        private readonly ILogger logger;

        public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        {
            this.Env = env;

            IConfigurationBuilder builder = new ConfigurationBuilder()
                  .SetBasePath(env.ContentRootPath)
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();

            this.logger = logger;
        }

        public IHostingEnvironment Env { get; set; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestDbContext>(
                options => options
                    .UseSqlServer(
                    this.Configuration["ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(60),
                            errorNumbersToAdd: null);
                    }));

            AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            services.AddSingleton(config.CreateMapper());

            services.AddSingleton<IConfiguration>(this.Configuration);

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.AddCors();

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            services.AddMvc();

            services.RegisterAppServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TestDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader().WithExposedHeaders("Pagination-Count", "Pagination-Page", "Pagination-Limit", "Content-Disposition");
            });

            app.UseHttpsRedirection();
            app.UseHsts();

            app.UseMvc();
        }
    }
}
