using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Accounts;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Infrastructure.DataAccess;
using Timewaster.Infrastructure.Identity;
using Timewaster.Web.Configurations;

namespace Timewaster.Web
{
    public class Startup
    {
        private IServiceCollection _services;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCookieSettings();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                       .AddEntityFrameworkStores<AppIdentityDbContext>()
                                       .AddDefaultTokenProviders();

            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

            services.AddCoreServices(Configuration);
            services.AddWebServices(Configuration);

            services.AddDbContext<TimewasterDbContext>(option =>
               option.UseSqlServer(Configuration.GetConnectionString("TimewasterConnection")));
            services.AddDbContext<AppIdentityDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddControllersWithViews();
            _services = services;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
