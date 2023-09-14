using Microsoft.Extensions.DependencyInjection;
using MVCRestaurant.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application
{
    public static class ServiceDependencyInjection
    {
        public static void AddCustomServices(this IServiceCollection service)
        {
            service.AddScoped<UserService>();
            service.AddScoped<FoodCategoryService>();
            service.AddScoped<FoodService>();
            service.AddScoped<OrderService>();
            service.AddScoped<InitService>();
            service.AddSingleton<FileService>();
            service.AddScoped<CookieHelper>();
            service.AddScoped<LogService>();
        }
    }
}
