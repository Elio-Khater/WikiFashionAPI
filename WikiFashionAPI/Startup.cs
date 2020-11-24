using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Managers;
using DAL.Interfaces;
using DAL.Repositories;
using DAL_EF.Implementations;
using DAL_EF.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WikiFashionAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string origin = "_myorigin";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IValuesManager, ValuesManager>();
            services.AddScoped<ICategoriesManager, CategoriesManager>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IUsersManager, UsersManager>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICountryManager, CountryManager>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IAgenciesManager, AgenciesManager>();
            services.AddScoped<IAgenciesRepository, AgenciesRepository>();
            services.AddScoped<ICategoriesRepositoryEF, CategoriesRepositoryEF>();
            services.AddScoped<IUsersRepositoryEF, UsersRepositoryEF>();
            services.AddCors(options =>
            {
                options.AddPolicy(origin,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseStaticFiles();
            app.UseCors(origin);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
