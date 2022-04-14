using System;
using E_Learning.Learning.Areas.Identity.Data;
using E_Learning.Learning.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(E_Learning.Learning.Areas.Identity.IdentityHostingStartup))]
namespace E_Learning.Learning.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<E_LearningLearningContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("PostgreDB")));

                services.AddDefaultIdentity<E_LearningLearningUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<E_LearningLearningContext>();
            });
        }
    }
}