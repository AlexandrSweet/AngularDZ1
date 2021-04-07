using AngularDZ1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.UserService;
using System.Linq;
using DataAccessLayer.Entities;
using BusinessLayer.DataServicePublic;
using BusinessLayer.Filters;

namespace AngularDZ1
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment.EnvironmentName}.json").Build(); ;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(MyFilter));
            });            

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration["SqlServerConnectionString"], 
                    b => b.MigrationsAssembly("DataAccessLayer"));
            });
            
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["LocalHost"],
                    ValidAudience = Configuration["LocalHost"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"))
                };
            });
                       
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IPrivateDataService, PrivateDataService>();
            services.AddScoped<IPublicDataService, PublicDataService>();
            services.AddScoped<MyFilter>();            

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            SeedDefaultUsersPrivate(app);
            SeedDefaultUsersPublic(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void SeedDefaultUsersPrivate(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.UserPrivate.FirstOrDefault(u => u.FirstName == "Denis") == null)
                {
                    UserPrivate Denis = new UserPrivate { FirstName = "Denis", LastName = "Popandopalo" };
                    UserPrivate Denis2 = new UserPrivate { FirstName = "Denis2", LastName = "Popandopalo2" };
                    UserPrivate Denis3 = new UserPrivate { FirstName = "Denis3", LastName = "Popandopalo3" };
                    UserPrivate Denis4 = new UserPrivate { FirstName = "Denis4", LastName = "Popandopalo4" };
                    UserPrivate Denis5 = new UserPrivate { FirstName = "Denis5", LastName = "Popandopalo5" };
                    
                    dbContext.UserPrivate.Add(Denis);
                    dbContext.UserPrivate.Add(Denis2);
                    dbContext.UserPrivate.Add(Denis3);
                    dbContext.UserPrivate.Add(Denis4);
                    dbContext.UserPrivate.Add(Denis5);

                    dbContext.SaveChanges();

                }

            }
        }

        private void SeedDefaultUsersPublic(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.UserPublic.FirstOrDefault(u => u.FirstName == "PublicDenis") == null)
                {
                    UserPublic UsersPublicDenis =  new UserPublic { FirstName = "PublicDenis", LastName = "Popandopalo" };
                    UserPublic UsersPublicDenis2 = new UserPublic { FirstName = "PublicDenis2", LastName = "Popandopalo2" };
                    UserPublic UsersPublicDenis3 = new UserPublic { FirstName = "PublicDenis3", LastName = "Popandopalo3" };
                    UserPublic UsersPublicDenis4 = new UserPublic { FirstName = "PublicDenis4", LastName = "Popandopalo4" };
                    UserPublic UsersPublicDenis5 = new UserPublic { FirstName = "PublicDenis5", LastName = "Popandopalo5" };

                    dbContext.UserPublic.Add(UsersPublicDenis);
                    dbContext.UserPublic.Add(UsersPublicDenis2);
                    dbContext.UserPublic.Add(UsersPublicDenis3);
                    dbContext.UserPublic.Add(UsersPublicDenis4);
                    dbContext.UserPublic.Add(UsersPublicDenis5);

                    dbContext.SaveChanges();

                }

            }
        }
    }
}
