using System;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EmployeeManagement.Areas.Identity.IdentityHostingStartup))]
namespace EmployeeManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EmployeeManagementDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EmployeeManagementDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedEmail = false)
                    .AddEntityFrameworkStores<EmployeeManagementDbContext>();
                //services.AddDefaultIdentity<ApplicationUser>(options =>
                //{
                //    options.SignIn.RequireConfirmedAccount = false;
                //    options.Password.RequireLowercase = false;
                //    options.Password.RequireUppercase = false;
                //    options.Password.RequiredUniqueChars = 0;
                //    options.Password.RequireNonAlphanumeric = false;
                //    options.User.AllowedUserNameCharacters =
                //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                //    options.User.RequireUniqueEmail = true;

                //});
            });
        }
    }
}