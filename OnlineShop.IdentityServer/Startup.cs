using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineShop.IdentityServer.Data;
using OnlineShop.IdentityServer.Models;

namespace OnlineShop.IdentityServer
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddIdentityServer()
               .AddDeveloperSigningCredential()
               .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryApiScopes(Config.GetApiScopes())
                .AddAspNetIdentity<ApplicationUser>();

            services.AddControllersWithViews(option =>
            {
                option.EnableEndpointRouting = false;
            });

            //services.AddIdentityServer()
            // .AddTestUsers(Config.GetTestUsers().ToList())
            //.AddDeveloperSigningCredential()
            ////.AddOperationalStore(options =>
            ////{
            ////    options.ConfigureDbContext = builder => builder.UseSqlServer(Configuration.GetConnectionString("Default"));
            ////    options.EnableTokenCleanup = true;
            ////    options.TokenCleanupInterval = 30;
            ////})
            ////.AddInMemoryIdentityResources(Config.GetIdentityResources())
            //.AddInMemoryClients(Config.GetClients())
            //.AddInMemoryApiResources(Config.GetApiResources());

            ////.AddAspNetIdentity<ApplicationUser>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("default", policy =>
            //    {
            //        policy.WithOrigins(Configuration["clientUrl"])
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //});
            //services.AddMvc(option =>
            //{
            //    option.EnableEndpointRouting = false;
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseIdentityServer();
            SeedData.SeedRoles(roleManager);
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "api", template: "api/{controller=Auth}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
