﻿namespace Incentives.Services.Membership.API
{
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using Incentives.Services.Membership.API.Models;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using NJsonSchema;
    using NSwag.AspNetCore;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(t =>
                {
                    t.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("app_membership"), ServiceLifetime.Singleton);
            //options.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
            services.AddSwagger();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}