using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Hubs;
using FMCApp.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FMCApp.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FMCApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<FMCAppContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<FMCAppUser,IdentityRole>(
                    options =>
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 4;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                    }
                    )
                .AddEntityFrameworkStores<FMCAppContext>();
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IUserReviewsService, UserReviewsService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IMovieService, MovieService>();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Administration", policy => policy.RequireRole("Administrator"));
            //}); /*// TODO : Let's say, hypothetically, that we have a controller we only want to give our super admin access to. We can apply an authorization policy using the Policy property on the Authorize attribute. To use policy based role checks, we register the policy at startup*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            RoleSeeder.Seed(provider);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSignalR(
                routes =>   
                {
                    routes.MapHub<ChatHub>("/OpenChat");
                }
                );
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
