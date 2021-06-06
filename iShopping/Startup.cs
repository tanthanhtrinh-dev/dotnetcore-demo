using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using iShopping.Helper;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace iShopping
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<iShoppingDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("iShoppingContext");

                if (Environment.IsDevelopment())
                {
                    //options.UseSqlite(connectionString);
                    options.UseSqlServer(connectionString);
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }
            });
            //services.AddScoped<>();
            //services.AddDbContext<iShoppingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("iShoppingContext")));
            services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<iShoppingDbContext>()
        .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddRazorPagesOptions(options =>
                {
                    //options.AllowAreas = true;
                    //options.Conventions.AuthorizeAreaFolder("", "/User/Manage");
                    //options.Conventions.AuthorizeAreaPage("", "/User/Login");
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/User/Login";
                options.LogoutPath = $"/User/Logout";
                options.AccessDeniedPath = $"/User/AccessDenied";
            });

            // using Microsoft.AspNetCore.Identity.UI.Services;
            services.AddScoped<IEmailSender, EmailSender>();
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
            //Redirect from http to https            
            app.UseHttpsRedirection();

            //Use Static Files
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            //
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
