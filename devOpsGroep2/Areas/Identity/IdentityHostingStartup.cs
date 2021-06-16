using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using devOpsGroep2.Areas.Identity.Data;
using devOpsGroep2.Data;

[assembly: HostingStartup(typeof(devOpsGroep2.Areas.Identity.IdentityHostingStartup))]
namespace devOpsGroep2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<devOpsGroep2Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("devOpsGroep2ContextConnection")));

                services.AddDefaultIdentity<devOpsGroep2User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<devOpsGroep2Context>();
            });
        }
    }
}