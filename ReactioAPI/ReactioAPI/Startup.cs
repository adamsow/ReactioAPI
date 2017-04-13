﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReactioAPI.Core.Repositories;
using ReactioAPI.Infrastructure.Repositories;
using ReactioAPI.Infrastructure.Services;
using ReactioAPI.Infrastructure.Mappers;
using ReactioAPI.Core.Data;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;

namespace ReactioAPI
{
    public class Startup
    {
        private string connectionString = null;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            connectionString = Configuration["DefaultConnection"];
            // Add framework services.
            services.AddMvc();
            services.AddScoped<IReactionRepository, DBReactionRepository>();
            services.AddScoped<IReactionService, ReactionService>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddDbContext<ReactioContext>(options 
                => options.UseSqlServer(connectionString ?? Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            
            env.ConfigureNLog("NLog.config");

            app.UseMvc();
        }
    }
}
