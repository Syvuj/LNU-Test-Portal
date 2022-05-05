using Business_Layer.Services;
using Business_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Entities;
using Data_Access_Layer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System.IO;
using Microsoft.Extensions.Logging;

namespace LNU_Test_Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITestService, TestService>();
            services.AddIdentity<ApplicationUser, IdentityRole>(config=> {
                //config.SignIn.RequireConfirmedEmail = true;
            })
        .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

           // services.AddMailKit(config => config.UseMailKit(Configuration.GetSection("Email").Get<MailKitOptions>()));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<DbContext, DataContext>();



            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/Account/Login";
            }
            );

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
           // var path = Directory.GetCurrentDirectory();
           // loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //AddData.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Course}/{action=GetAllCourses}/{id?}");

            });
        }
    }
}
