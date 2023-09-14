using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using MVCRestaurant.Application;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Mapper;
using MVCRestaurant.Models;
using MVCRestaurant.ViewModels;
using System.Data;
using System.Net;
using System.Security.Claims;
using System.Xml.Linq;

namespace MVCRestaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly FoodCategoryService _FCS;
        private readonly FoodService _FS;
        private readonly CookieHelper _CH;
        private readonly LogService _Ls;

        public MenuController(FoodCategoryService FCS, FoodService FS, CookieHelper CH, LogService Ls)
        {
            _FCS = FCS;
            _FS = FS;
            _CH = CH;
            _Ls = Ls;
        }

        [HttpGet]
        public async Task<ActionResult> Main()
        {
            List<FoodCategoryViewModel> categories = (await _FCS.GetAllCategories())
                .Select(x => FoodMapper.CategoryToVM(x)).ToList();
            return View(categories);
        }

        [HttpGet]
        public async Task<ActionResult> FoodList(ulong categoryId = 2, int pageNum = 1)
        {
            string orderId;
            if (!_CH.CookieExists(this, "OrderIdentifier"))
            {
                orderId = await _CH.CreateCookieOrderIdentifier(this, "OrderIdentifier");
                ViewBag.orderDic = new Dictionary<ulong, string>();
            }
            else
            {
                orderId = _CH.GetCookie(this, "OrderIdentifier");
                ViewBag.orderDic = await _CH.GetFoodCountDictionaryFromCookie(orderId);
            }

            List<FoodItemViewModel> foods = (await _FS.GetFoodList(pageNum, null, categoryId)).Item1
                .Select(x => FoodMapper.FoodToVM(x)).ToList();

            return View(foods);
        }

        #region Administration-related

        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<ActionResult> Index()
        {
            return View((await _FCS.GetAllCategories())
                .Select(x => FoodMapper.CategoryToVM(x)).ToList());
        }

        // GET: MenuController/Details/5
        [Authorize(Roles = "Employee, Admin, SuperAdmin")]
        public async Task<ActionResult> Details(ulong categoryId)
        {
            FoodCategoryViewModel foodCategory = FoodMapper.CategoryToVM(await _FCS.GetCategory(categoryId));
            return View(foodCategory);
        }

        // GET: MenuController/Create
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Create(FoodCategoryViewModel foodCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //throw new Exception("eeeeeee");
                    Result res = await _FCS.CreateCategory(FoodMapper.VMtoCategory(foodCategory), this.User.FindFirstValue("AltKey")??"N/A");
                    if (!res.HasError)
                    {
                        //log
                        await _Ls.AddLog(this.User, $"successfully created category {foodCategory.name}.", false);
                        //log
                        return Ok(new { succ = true });
                    }
                else
                    ModelState.AddModelError("", res.ErrorMessage);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            //log
            await _Ls.AddLog(this.User,$"Something went wrong while creating category {foodCategory.name}.", true);
            //log

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return View(foodCategory);
        }

        // GET: MenuController/Edit/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Edit(ulong categoryId)
        {
            FoodCategoryViewModel foodCategory = FoodMapper.CategoryToVM(await _FCS.GetCategory(categoryId));
            return View(foodCategory);
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Edit(FoodCategoryViewModel foodCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Result res = await _FCS.EditCategory(FoodMapper.VMtoCategory(foodCategory), this.User.FindFirstValue("AltKey") ?? "N/A");
                    if (!res.HasError)
                    {
                        //log
                        await _Ls.AddLog(this.User, $"Successfully edited category {foodCategory.name}.", false);
                        //log
                        return PartialView(foodCategory);
                    }
                    else
                        ModelState.AddModelError("", res.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            //log
            await _Ls.AddLog(this.User, $"failed to edit category {foodCategory.name}.", true);
            //log

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView(foodCategory);
        }

        // GET: MenuController/Delete/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Delete(ulong categoryId)
        {
            
            FoodCategoryViewModel foodCategory = FoodMapper.CategoryToVM(await _FCS.GetCategory(categoryId));
            return PartialView(foodCategory);
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> DeletePost(ulong? categoryId)
        {
            try
            {
                if (categoryId != null && categoryId != 0)
                { 
                    Result res = await _FCS.DeleteCategory(categoryId.GetValueOrDefault(), this.User.FindFirstValue("AltKey") ?? "N/A");
                    if (!res.HasError)
                    {
                        //log
                        await _Ls.AddLog(this.User, $"Successfully deleted category {categoryId}.", false);
                        //log
                        return PartialView();
                    }
                    else
                        ModelState.AddModelError("", res.ErrorMessage);
                }
                else
                {
                    ModelState.AddModelError("", "Menu ID cannot be null or zero.");
                }
            }
            catch(Exception ex)
            {
                //log
                await _Ls.AddLog(this.User, $"Failed to deleted category {categoryId}.", true);
                //log
                ModelState.AddModelError("", ex.Message);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView(FoodMapper.CategoryToVM(await _FCS.GetCategory(categoryId.GetValueOrDefault())));
        }

        #endregion
    }
}
