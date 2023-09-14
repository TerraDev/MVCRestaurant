using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Infrastructure
{
    public static class DefineDB
    {
        public static void AddCustomDbContext(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<AppDbContext>(options =>
            {
                //options.EnableSensitiveDataLogging();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(
                connectionString
                , b => b.MigrationsAssembly("MVCRestaurant.Infrastructure"));
            });

            //I searched for difference between AddIdentityCore, AddIdentity & AddDefaultIdentity
            //AddIdentity & AddDefaultIdentity provide SignInManager
            service.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            service.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 5;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"
                + "اآضصثقفغعهخحجچپشسی‌بلاتنمکگظطزرذدئوۀةيژؤإأء";
                //options.Tokens.
            });

            service.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
            opt =>
            {
                //configure your other properties
                opt.LoginPath = "/User/Login";
                opt.LogoutPath = "/User/Logout";
                opt.AccessDeniedPath = "/User/Unauthorized";
            });

            // services.AddDefaultIdentity<ApplicationUser>(options=> //or <IdentityUser>
            //options.SignIn.RequireConfirmedAccount = true)
            //  .AddEntityFrameworkStores<AppDbContext>();
            // --> add package Microsoft.AspNetCore.Identity.UI
        }


        public static void CreateDataBaseIfNotExists(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
