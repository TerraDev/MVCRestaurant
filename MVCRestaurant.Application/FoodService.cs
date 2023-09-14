using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Infrastructure;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application
{
    public class FoodService
    {
        
        private readonly AppDbContext _ctx;
        private readonly FileService _fs;

        public FoodService(AppDbContext ctx, FileService fs)
        {
            _ctx = ctx;
            _fs = fs;
        }

        public async Task<Result> AddFood(FoodItem food, IFormFile file, string userId)
        {
            using (IDbContextTransaction tx = _ctx.Database.BeginTransaction())
            {
                food.CreateDate = DateTime.Now;
                food.IsDeleted = false;
                food.IsDisable = false;
                food.CreatedBy = userId;
                await _ctx.FoodItems.AddAsync(food);

                if (file != null)
                {
                    string picPath = await _fs.StoreFileAsync(file, "Images\\Food");
                    food.ImagePath = picPath;
                }

                if (await _ctx.SaveChangesAsync() > 0)
                {
                    await tx.CommitAsync();
                    return new Result { HasError = false };
                }
                else
                {
                    await tx.RollbackAsync();
                    return new Result { HasError = true, ErrorMessage = "افزودن غذا با شکست مواجه شد." };
                }
            }
        }

        public async Task<Result> EditFood(FoodItem food, IFormFile file, string UserId)
        {
            if (!_ctx.FoodItems.Any(x => x.Id == food.Id))
            {
                throw new Exception("غذا وجود ندارد!");
            }

            using (IDbContextTransaction tx = _ctx.Database.BeginTransaction())
            {
                FoodItem foodItem = await _ctx.FoodItems.SingleAsync(x => x.Id == food.Id);
                foodItem.LastModifiedDate = DateTime.Now;
                foodItem.LastModifiedBy = UserId;
                foodItem.Name = food.Name;
                foodItem.Price = food.Price;
                foodItem.CategoryId = food.CategoryId;


                if (file != null)
                {
                    string picPath = await _fs.StoreFileAsync(file, "Images/Food");
                    foodItem.ImagePath = picPath;
                }

                _ctx.Entry<FoodItem>(foodItem).State = EntityState.Modified;
                if (await _ctx.SaveChangesAsync() > 0)
                {
                    await tx.CommitAsync();
                    return new Result { HasError = false };
                }
                else
                    return new Result { HasError = true, ErrorMessage = "ویرایش غذا با شکست مواجه شد." };
            }
        }

        public async Task<Result> DeleteFoodItem(ulong id, string UserId)
        {
            if (!_ctx.FoodItems.Any(x => x.Id == id))
            {
                throw new Exception("غذا وجود ندارد!");
            }

            FoodItem food = _ctx.FoodItems.AsTracking().Single(x => x.Id == id);
            food.LastDeletedBy = UserId;
            food.IsDeleted = true;

            _ctx.Entry<FoodItem>(food).State = EntityState.Modified;
            if (await _ctx.SaveChangesAsync() > 0)
                return new Result { HasError = false };
            else
                return new Result { HasError = true, ErrorMessage = "حذف غذا صورت نپذیرفت.." };
        }

        public async Task<FoodItem> GetFoodDetails(ulong id)
        {
            return await _ctx.FoodItems.Include(x => x.Category).SingleAsync(x => x.Id == id);
        }

        public async Task<(List<FoodItem>, int)> GetFoodList(int pageNum = 1, string? nameFilter=null, ulong categoryId = 0)
        {
            bool noName = string.IsNullOrEmpty(nameFilter);
            bool noCategory = categoryId == 0;
            IQueryable<FoodItem> AllFoods = null;

            if (noName & noCategory)
            {
                AllFoods = _ctx.FoodItems;
            }
            else if(noName & !noCategory)
            {
                AllFoods = _ctx.FoodItems.Where(x => x.CategoryId == categoryId);
                //.Include(x => x.Category).Page(8, pageNum).ToListAsync();
            }
            else if(!noName & noCategory)
            {
                AllFoods = _ctx.FoodItems
                    .Where(x => x.Name.ToLower().Contains(nameFilter!));
                    //.Page(8, pageNum).Include(x => x.Category).ToListAsync();
            }
            else //if(!noName & !noCategory)
            {
                AllFoods = _ctx.FoodItems
                        .Where(x => x.CategoryId == categoryId && x.Name.ToLower().Contains(nameFilter!));
                        //.Page(8, pageNum).Include(x => x.Category).ToListAsync();
            }

            return (await AllFoods.Page(8, pageNum).Include(x => x.Category).ToListAsync(),
                 (int)Math.Ceiling(await AllFoods.CountAsync()/8f));
        }

        public async Task<Result> RemoveFoodImage(ulong id)
        {
            FoodItem food = _ctx.FoodItems.AsTracking().Single(x => x.Id == id);
            if (food == null)
            {
                throw new Exception("غذا وجود ندارد!");
            }

            if(string.IsNullOrEmpty(food.ImagePath))
            {
                throw new Exception("عکس یافت نشد!");
            }

            food.ImagePath = null;


            _ctx.Entry<FoodItem>(food).State = EntityState.Modified;
            if (await _ctx.SaveChangesAsync() > 0)
                return new Result { HasError = false };
            else
                return new Result { HasError = true, ErrorMessage = "حذف غذا صورت نپذیرفت." };
        }
    }
}
