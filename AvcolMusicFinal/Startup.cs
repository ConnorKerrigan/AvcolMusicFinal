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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AvcolMusicFinal.Areas.Identity.Data;
using AvcolMusicFinal.Models;

namespace AvcolMusicFinal
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
            
            services.AddDbContext<MusicContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //throw new Exception(Configuration.GetConnectionString("DefaultConnection"));



            services.AddIdentity<ACUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddDefaultUI()
                 .AddEntityFrameworkStores<MusicContext>()
                 .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("adminPolicy", builder => builder.RequireRole("Admin"));
                options.AddPolicy("teacherPolicy", builder => builder.RequireRole("Admin", "Teacher"));
                options.AddPolicy("studentPolicy", builder => builder.RequireRole("Admin", "Teacher", "Student"));
            });
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
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
            Seeder.Initialize(app.ApplicationServices.CreateScope().ServiceProvider);
        }
    }
}
