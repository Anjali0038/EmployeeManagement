using System;
using EmployeeManagement.Data;
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

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedEmail = false)
                    .AddEntityFrameworkStores<EmployeeManagementDbContext>();
            });
        }
    }
}