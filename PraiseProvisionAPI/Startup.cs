﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PraiseProvisionAPI.Models.Interfaces;
using PraiseProvisionAPI.Models.Services;
using PraiseProvisionsAPI.Data;

namespace PraiseProvisionsAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            var cb = new ConfigurationBuilder().AddEnvironmentVariables();
            cb.AddUserSecrets<Program>();
            Configuration = cb.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PraiseDBContext>(options =>
            {
               options.UseSqlServer(Configuration.GetConnectionString("ProductionDB"));
            });

            services.AddTransient<IChef, ChefService>();
            services.AddTransient<IRestaurant, RestaurantService>();
            services.AddTransient<IFavorite, FavoriteService>();
            services.AddTransient<IRecommendation, RecommendationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
