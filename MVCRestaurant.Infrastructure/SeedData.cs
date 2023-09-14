using Microsoft.AspNetCore.Identity;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Infrastructure
{
    internal static class SeedData
    {
        public static List<IdentityRole> GetSeedRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole(RolesEnum.Customer.ToString())
                {
                    NormalizedName = RolesEnum.Customer.ToString().ToUpper(),
                    Id = "D0074DD6-E540-45D4-A804-5E1A42C81661"
                },
                new IdentityRole(RolesEnum.Employee.ToString())
                {
                    NormalizedName = RolesEnum.Employee.ToString().ToUpper(),
                    Id = "5E1C722F-5CD8-45F4-94A9-14508F2C8E54"
                },
                new IdentityRole(RolesEnum.Admin.ToString())
                {
                    NormalizedName = RolesEnum.Admin.ToString().ToUpper(),
                    Id = "29D9873B-8339-4E70-8DE4-544507529A74"
                },
                new IdentityRole(RolesEnum.SuperAdmin.ToString())
                {
                    NormalizedName = RolesEnum.SuperAdmin.ToString().ToUpper(),
                    Id = "15337A34-8592-4417-8C9E-ACF960B00102"
                }
            };
        }

        public static List<AppUser> GetSeedUsers()
        {
            AppUser appUser1 = new AppUser()
            {
                Email = "XXXXXXXXXXXXXX@X.com",
                NormalizedEmail = "XXXXXXXXXXXXXX@X.com".ToUpper(),
                EmailConfirmed = true,
                Id = "B37C0271-DDD7-4124-AD52-69360F5A219F",
                AltKey = 1,
                UserName = "XXXXXXXXXXXXXX",
                NormalizedUserName = "XXXXXXXXXXXXXX".ToUpper(),
            };

            var hasher = new PasswordHasher<AppUser>();
            //hasher.HashPassword(appUser, "secret123");
            appUser1.PasswordHash = hasher.HashPassword(appUser1, "secret123");
            
            //AppUser appUser2 = new AppUser()
            //{
            //    Email = "admin@g.com",
            //    NormalizedEmail = "admin@g.com".ToUpper(),
            //    EmailConfirmed = true,
            //    Id = "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
            //    AltKey = 2,
            //    UserName = "ادمین",
            //    NormalizedUserName = "ادمین".ToUpper(),
            //};

            //appUser2.PasswordHash = hasher.HashPassword(appUser2, "ASDQ98");
            
            return new List<AppUser>{ appUser1/*, appUser2*/ };
        }

        public static List<IdentityUserRole<string>> GetSeedUserRoles()
        {
            
            IdentityUserRole<string> userRole1 = new IdentityUserRole<string>()
            {
                UserId = "B37C0271-DDD7-4124-AD52-69360F5A219F",
                RoleId = "15337A34-8592-4417-8C9E-ACF960B00102"
            };

            //IdentityUserRole<string> userRole2 = new IdentityUserRole<string>()
            //{
            //    UserId = "7BA707E9-EC0E-45BA-98BE-0159CD6A3F1E",
            //    RoleId = "29D9873B-8339-4E70-8DE4-544507529A74"
            //};
            
            return new List<IdentityUserRole<string>> { userRole1/*,  userRole2*/  }; 
        }
    }
}
