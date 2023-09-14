using MVCRestaurant.Infrastructure;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application
{
    public class InitService
    {
        
        private readonly AppDbContext _ctx;

        public InitService(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task InitCategories(List<FoodCategory> categories)
        {
            categories.ForEach(x => 
            { 
                x.IsDeleted = false;
                x.IsDisable = false;
                x.CreateDate = DateTime.Now;
                x.CreatedBy = "Admin triggered db data initiation";
                x.Id = 0;
            });

            await _ctx.FoodCategories.AddRangeAsync(categories);
            await _ctx.SaveChangesAsync();
        }

        public async Task InitFood(List<FoodItem> foods)
        {
            foods.ForEach(x =>
            {
                x.IsDeleted = false;
                x.IsDisable = false;
                x.CreateDate = DateTime.Now;
                x.CreatedBy = "Admin triggered db data initiation";
            });

            await _ctx.FoodItems.AddRangeAsync(foods);
            await _ctx.SaveChangesAsync();
        }
        
    }
}
