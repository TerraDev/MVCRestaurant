using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCRestaurant.Application;
using MVCRestaurant.Mapper;
using MVCRestaurant.Models;
using MVCRestaurant.ViewModels.User;
using System.Security.Claims;

namespace MVCRestaurant.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly InitService _Is;
        private readonly LogService _Ls;
        private readonly UserService _Us;

        public AdminController(InitService Is, LogService Ls, UserService Us)
        {
            _Is = Is;
            _Ls = Ls;
            _Us = Us;
        }

        public IActionResult InitiateDbData()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitiateDbCategoryData()
        {
            //log
            await _Ls.AddLog(this.User.FindFirstValue("AltKey") ?? "N/A", 
                "Initiating DB categories with data", false);
            //log

            await _Is.InitCategories(
                TempDB.FoodCategoryDB.Select(x => Mapper.FoodMapper.VMtoCategory(x)).ToList()
                );

            return RedirectToAction("Main", "Menu");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitiateDbFoodData()
        {
            //log
            await _Ls.AddLog(this.User.FindFirstValue("AltKey") ?? "N/A",
                "Initiating DB Food with data", false);
            //log

            await _Is.InitFood(
                TempDB.FoodItemDB.Select(x => Mapper.FoodMapper.VMtoFood(x)).ToList()
                );

            return RedirectToAction("Main", "Menu");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitiateUserData()
        {
            //log
            await _Ls.AddLog(this.User.FindFirstValue("AltKey") ?? "N/A",
                "Initiating DB Food with User Data -Customer--Employee--Admin-", false);
            //log

            Dictionary<UserViewModel, string> users = new Dictionary<UserViewModel, string>() {
                {
                    new UserViewModel() { 
                    userName = "ادمین",
                    Email = "Admin@a.com",
                    Role = "Admin"
                    }, "Admin1"
                },
                {
                    new UserViewModel() {
                        userName = "کارمند",
                        Email = "Employee@e.com",
                        Role = "Employee"
                    }, "Employee1"
                },
                {
                    new UserViewModel() {
                        userName = "مشتری",
                        Email = "Customer@c.com",
                        Role = "Customer"
                    }, "Customer1"
                }
            };

            List<IdentityResult> results = new List<IdentityResult>();
            foreach (KeyValuePair<UserViewModel, string> x in users)
            {
                results.Add(await _Us.Register(UserMapper.VMtoUser(x.Key), x.Value, x.Key.Role));

            }

            foreach (IdentityResult res in results)
            {
                if(!res.Succeeded)
                {
                    return Json("Failed to Initialize users!");
                }
            }

            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> Logs(int pageNum = 1)
        {
            //log
            //await _Ls.AddLog(this.User.FindFirstValue("AltKey"),
            //    "Viewing Logs on page " + pageNum, false);
            //log

            (var l, ViewBag.TotalPages) = await _Ls.GetLogs(pageNum);

            return View(l.Select(x => LogMapper.LogToVM(x)));
        }
    }
}
