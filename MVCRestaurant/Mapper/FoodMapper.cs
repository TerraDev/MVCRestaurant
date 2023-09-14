using MVCRestaurant.Models;
using MVCRestaurant.ViewModels;

namespace MVCRestaurant.Mapper
{
    
    internal static class FoodMapper
    {

        internal static FoodCategoryViewModel CategoryToVM(FoodCategory category)
        {
            return new FoodCategoryViewModel()
            {
                id = category.Id,
                Icon = category.Icon,
                name = category.Name,
            };
        }

        internal static FoodCategory VMtoCategory(FoodCategoryViewModel categoryModel)
        {
            return new FoodCategory()
            {
                Id = categoryModel.id,
                Icon = categoryModel.Icon,
                Name = categoryModel.name,
            };
        }

        //Mappers for foodItem
        internal static FoodItemViewModel FoodToVM(FoodItem food)
        {
            return new FoodItemViewModel()
            {
                id = food.Id,
                ImagePath = food.ImagePath,
                name = food.Name,
                //TODO: change price type to ulong in database and remove cast
                price = food.Price,
                category = food.Category==null ? null : new FoodCategoryViewModel()
                {
                    id = food.CategoryId,
                    name = food.Category.Name
                    //icon?
                }
            };
        }

        
        internal static FoodItem VMtoFood(FoodItemViewModel foodModel)
        {
            return new FoodItem()
            {
                Id = foodModel.id,
                ImagePath = foodModel.ImagePath,
                Name = foodModel.name,
                //TODO: change price type to ulong in database and remove cast
                Price = foodModel.price,
                CategoryId = foodModel.category.id
            };
        }
    }
    
}
