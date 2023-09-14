using Microsoft.EntityFrameworkCore;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Infrastructure;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application
{

    public class FoodCategoryService
    {
        
        private readonly AppDbContext _ctx;

        public FoodCategoryService(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<Result> CreateCategory(FoodCategory _foodCat, string UserId)
        {
            _foodCat.CreateDate = DateTime.Now;
            _foodCat.IsDeleted = false;
            _foodCat.IsDisable = false;
            _foodCat.CreatedBy = UserId;
            await _ctx.FoodCategories.AddAsync(_foodCat);
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return new Result { HasError = false};
            }
            else return new Result { HasError = true, ErrorMessage = "Failed to add item"};
        }

        public async Task<Result> EditCategory(FoodCategory _foodCat, string UserId)
        {
            if (!_ctx.FoodCategories.Any(x => x.Id == _foodCat.Id))
            {
                throw new Exception("دسته غذایی وجود ندارد!");
            }
            FoodCategory category = await _ctx.FoodCategories.SingleAsync(x => x.Id == _foodCat.Id);
            category.LastModifiedDate = DateTime.Now;
            category.LastModifiedBy = UserId;
            category.Name = _foodCat.Name;
            category.Icon = _foodCat.Icon;

            _ctx.Entry<FoodCategory>(category).State = EntityState.Modified;

            if (await _ctx.SaveChangesAsync() > 0)
            {
                return new Result { HasError = false };
            }
            else return new Result { HasError = true, ErrorMessage = "Failed to update item" };
        }

        public async Task<Result> DeleteCategory(ulong categoryId, string UserId)
        {
            if (!_ctx.FoodCategories.Any(x => x.Id == categoryId))
            {
                throw new Exception("دسته غذایی وجود ندارد!");
            }

            if (_ctx.FoodItems.Any(x => x.Category.Id == categoryId))
            {
                return new Result
                {
                    HasError = true,
                    ErrorMessage = "برای حذف این دسته باید ابتدا تمام" +
                    " غذاهای این دسته حذف شوند."
                };
            }

            FoodCategory category = await _ctx.FoodCategories.AsTracking().SingleAsync(x => x.Id == categoryId);
            category.LastDeletedBy = UserId;
            // TODO: create deleteDate in base entity
            category.IsDeleted = true;
            _ctx.Entry<FoodCategory>(category).State = EntityState.Modified;
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return new Result { HasError = false };
            }
            else return new Result { HasError = true, ErrorMessage = "حذف دسته با شکست مواجه شد." };
        }

        public async Task<FoodCategory> GetCategory(ulong id)
        {
            return await _ctx.FoodCategories.SingleAsync(x => x.Id == id);
        }

        public async Task<List<FoodCategory>> GetAllCategories()
        {
            return await _ctx.FoodCategories.ToListAsync();
        }

        public async Task<List<FoodCategory>> SearchCategories(string name)
        {
            return await _ctx.FoodCategories.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }
        
    }
}
