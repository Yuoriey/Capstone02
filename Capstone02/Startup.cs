
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Capstone02.Data;
using Newtonsoft.Json.Serialization;
using Capstone02.Controllers;
namespace Capstone02
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


            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();

            
            services.AddRazorPages();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

      
            services.AddHttpClient();

            services.AddSignalR();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6; // You can set this to your desired minimum length
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {               
            //Enable Cors



            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //JSON SERIALIZER


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                app.UseHttpsRedirection();
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGet("/", async context =>
                {
                    if (context.User.Identity.IsAuthenticated)
                    {
                        context.Response.Redirect("/Home/Index");
                    }
                    else
                    {
                        context.Response.Redirect("Identity/Account/Login");
                    }
                   
                });
               
                endpoints.MapControllerRoute(
                    name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "redcross",
                pattern: "RedCross/{action=Index}/{id?}",
                defaults: new { controller = "RedCrosses" });

                endpoints.MapControllerRoute(
                name: "ptamembership",
                pattern: "PTAMembership/{action=Index}/{id?}",
                defaults: new { controller = "PTAMemberships" });

                endpoints.MapControllerRoute(
                name: "learnersareas",
                pattern: "LearnersAreas/{action=Index}/{id?}",
                defaults: new { controller = "LearnersAreas" });

                endpoints.MapControllerRoute(
                name: "insurance",
                pattern: "Insurance/{action=Index}/{id?}",
                defaults: new { controller = "Insurances" });

                endpoints.MapControllerRoute(
                name: "publication",
                pattern: "Publications/{action=Index}/{id?}",
                defaults: new { controller = "Publications" });

                endpoints.MapControllerRoute(
                name: "boygirlscout",
                pattern: "BoyGirlScouts/{action=Index}/{id?}",
                defaults: new { controller = "BoyGirlsScouts" });

                endpoints.MapControllerRoute(
                name: "anti_tbfunddrive",
                pattern: "Anti_TBFundDrive/{action=Index}/{id?}",
                defaults: new { controller = "Anti_TBFundDrive" });

                endpoints.MapControllerRoute(
                name: "rfid",
                pattern: "RFIDs/{action=Index}/{id?}",
                defaults: new { controller = "RFIDs" });

                endpoints.MapControllerRoute(
                name: "ssg",
                pattern: "SSGs/{action=Index}/{id?}",
                defaults: new { controller = "SSGs" });

                endpoints.MapControllerRoute(
                name: "gptaelectricity",
                pattern: "GPTAElectricities/{action=Index}/{id?}",
                defaults: new { controller = "GPTAElectricities" });

                endpoints.MapControllerRoute(
                name: "athleticssportsfund",
                pattern: "AthleticsSportsFunds/{action=Index}/{id?}",
                defaults: new { controller = "AthleticsSportsFunds" });

                endpoints.MapControllerRoute(
                name: "researchfund",
                pattern: "ResearchFunds/{action=Index}/{id?}",
                defaults: new { controller = "ResearchFunds" });


                endpoints.MapRazorPages();
            });
        }

    }
}
