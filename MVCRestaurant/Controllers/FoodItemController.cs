using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCRestaurant.Application;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Mapper;
using MVCRestaurant.Models;
using MVCRestaurant.ViewModels;
using System.Net;
using System.Security.Claims;

namespace MVCRestaurant.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly FoodService _Fs;
        private readonly FoodCategoryService _FCs;
        private readonly CookieHelper _CH;
        private readonly LogService _Ls;

        public FoodItemController(FoodService Fs, FoodCategoryService FCs, CookieHelper CH, LogService Ls)
        {
            _Fs = Fs;
            _FCs = FCs;
            _CH = CH;
            _Ls = Ls;
        }

        public async Task<IActionResult> Details2(ulong foodId)
        {
            string orderId;
            if (!_CH.CookieExists(this, "OrderIdentifier"))
            {
                orderId = await _CH.CreateCookieOrderIdentifier(this, "OrderIdentifier");
                ViewBag.orderDic = new Dictionary<ulong,uint>();
            }
            else
            {
                orderId = _CH.GetCookie(this, "OrderIdentifier");
                ViewBag.orderDic = await _CH.GetFoodCountDictionaryFromCookie(orderId);
            }
            FoodItemViewModel food = FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId));
            return View(food);
        }

        #region Administration-related
        [HttpGet]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> Index(int pageNum = 1, string? nameFilter = null, ulong categoryFilter = 0)
        {
            (var f, ViewBag.TotalPages) = await _Fs.GetFoodList(pageNum, nameFilter, categoryFilter);
            List<FoodItemViewModel> foodItems = f.Select(x => FoodMapper.FoodToVM(x)).ToList();

            ViewBag.categories = (await _FCs.GetAllCategories()).Select(x =>
            new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            return View(foodItems);
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = (await _FCs.GetAllCategories()).Select(x => {
                var y = FoodMapper.CategoryToVM(x);
                return new SelectListItem { Text = y.name, Value = y.id.ToString() };
            });

            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> Create(IFormFile? image, FoodItemViewModel foodItem)
        {
            try
            {
                ModelState[nameof(foodItem.id)].ValidationState = ModelValidationState.Skipped;
                ModelState[
                    nameof(foodItem.category)+"."+nameof(foodItem.category.name)
                    ].ValidationState = ModelValidationState.Skipped;
                ModelState[nameof(foodItem.ImagePath)].ValidationState = ModelValidationState.Skipped;

                if (ModelState.IsValid)
                {
                    Result res = await _Fs.AddFood(FoodMapper.VMtoFood(foodItem), image, 
                        this.User.FindFirstValue("AltKey")??"N/A");
                    if (!res.HasError)
                    {
                        //log
                        await _Ls.AddLog(this.User.FindFirstValue("AltKey") ?? "N/A",
                            "successfully created new food item", false);
                        //log

                        return Ok(new { succ = true });
                    }
                    else
                        ModelState.AddModelError("", res.ErrorMessage);
                }

                ViewBag.categories = (await _FCs.GetAllCategories()).Select(x => {
                    var y = FoodMapper.CategoryToVM(x);
                    return new SelectListItem { Text = y.name, Value = y.id.ToString() };
                });
                Response.StatusCode = ((int)HttpStatusCode.BadRequest);

                //log
                await _Ls.AddLog(this.User.FindFirstValue("AltKey") ?? "N/A",
                    "Invalid creation for food item " + foodItem.name, true);
                //log

                return PartialView(new { foodItem = foodItem, image = image });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                ViewBag.categories = (await _FCs.GetAllCategories()).Select(x => {
                    var y = FoodMapper.CategoryToVM(x);
                    return new SelectListItem { Text = y.name, Value = y.id.ToString() };
                });
                Response.StatusCode = ((int)HttpStatusCode.InternalServerError);

                //log
                await _Ls.AddLog(this.User.FindFirstValue("AltKey") ?? "N/A",
                    $"hit exception '{ex.Message}' while creating food item {foodItem.name}!", true);
                //log

                return PartialView(new { foodItem = foodItem, image = image });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(ulong foodId)
        {
            ViewBag.categories = (await _FCs.GetAllCategories()).Select(x => {
                var y = FoodMapper.CategoryToVM(x);
                return new SelectListItem { Text = y.name, Value = y.id.ToString() };
            });

            FoodItemViewModel food = FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId));

            return View("Create", food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(IFormFile? image, FoodItemViewModel foodItem)
        {
            try
            {
                //log
                await _Ls.AddLog(this.User.FindFirstValue("AltKey") ?? "N/A",
                    $"Editing food item '{foodItem.name}'.", false);
                //log

                ModelState[
                    nameof(foodItem.category) + "." + nameof(foodItem.category.name)
                ].ValidationState = ModelValidationState.Skipped;
                ModelState[nameof(foodItem.ImagePath)].ValidationState = ModelValidationState.Skipped;

                if (ModelState.IsValid)
                {
                    Result res = await _Fs.EditFood(FoodMapper.VMtoFood(foodItem), image, this.User.FindFirstValue("AltKey") ?? "N/A");
                    if (!res.HasError)
                        return Ok(new { succ = true });
                    else
                        ModelState.AddModelError("", res.ErrorMessage);
                }

                ViewBag.categories = (await _FCs.GetAllCategories()).Select(x => {
                    var y = FoodMapper.CategoryToVM(x);
                    return new SelectListItem { Text = y.name, Value = y.id.ToString() };
                });
                Response.StatusCode = ((int)HttpStatusCode.BadRequest);
                return PartialView("Create", new { foodItem = foodItem, image = image });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                ViewBag.categories = (await _FCs.GetAllCategories()).Select(x => {
                    var y = FoodMapper.CategoryToVM(x);
                    return new SelectListItem { Text = y.name, Value = y.id.ToString() };
                });
                Response.StatusCode = ((int)HttpStatusCode.InternalServerError);

                await _Ls.AddLog(this.User,
                    $"Hit exception '{ex.Message}' while Editing food item '{foodItem.name}'.", true); //Log
                return PartialView("Create", new { foodItem = foodItem, image = image });
            }
            //return OK(new {succ = true}) //pass
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(ulong foodId)
        {
            return View(FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> DeletePost(ulong foodId)
        {
            try
            {
                //log
                await _Ls.AddLog(this.User.FindFirstValue("AltKey") ?? "N/A",
                    $"Deleting food item '{foodId}'.", false);
                //log

                Result res = await _Fs.DeleteFoodItem(foodId, this.User.FindFirstValue("AltKey") ?? "N/A");
                    if (!res.HasError)
                        return Ok(new { succ = true });
                    else
                        ModelState.AddModelError("", res.ErrorMessage);
                Response.StatusCode = ((int)HttpStatusCode.BadRequest);
                return PartialView(FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                Response.StatusCode = ((int)HttpStatusCode.InternalServerError);

                await _Ls.AddLog(this.User,$"hit exc {ex.Message} while deleting food item '{foodId}'.", true);//log

                return PartialView(FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId)));
            }
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> DeleteImage(ulong foodId)
        {
            return View(FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(DeleteImage))]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> DeleteImagePost(ulong foodId)
        {
            try
            {
                //log
                await _Ls.AddLog(this.User.FindFirstValue("AltKey")??"N/A",
                    $"Deleting image of food item '{foodId}'.", false);
                //log

                Result res = await _Fs.RemoveFoodImage(foodId);
                if (!res.HasError)
                    return Ok(new { succ = true });
                else
                    ModelState.AddModelError("", res.ErrorMessage);
                Response.StatusCode = ((int)HttpStatusCode.BadRequest);
                return PartialView(FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                Response.StatusCode = ((int)HttpStatusCode.InternalServerError);
                //log
                await _Ls.AddLog(this.User, 
                    $"hit exc {ex.Message} while deleting image of food item '{foodId}'.", false); 
                // log
                return PartialView(FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId)));
            }
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<IActionResult> Details(ulong foodId)
        {
            return View(FoodMapper.FoodToVM(await _Fs.GetFoodDetails(foodId)));
        }
        #endregion
    }
}
