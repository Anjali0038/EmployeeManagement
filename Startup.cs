using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfigurationRoot _config;
        public Startup(IWebHostEnvironment env)
        {
            var ConfigBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                       .AddJsonFile("appsettings.json");
            _config = ConfigBuilder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));
            services.AddSingleton(_config);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<EmployeeManagementDbContext>();
            //services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
           // services.AddScoped(typeof(IEmployeeProvider), typeof(EmployeeProvider));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            services.AddScoped<IEmployeeProvider, EmployeeProvider>();
            services.AddScoped<IApplicationUserProvider, ApplicationUserProvider>();

            // services.RegisterServiceDependencies();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
