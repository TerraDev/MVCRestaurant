using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCRestaurant.Application;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Mapper;
using MVCRestaurant.Models;
using MVCRestaurant.ViewModels.User;
using System.Net;

namespace MVCRestaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly LogService _Ls;

        public UserController(UserService userService, LogService Ls)
        {
            _userService = userService;
            _Ls = Ls;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res1 = await _userService.Register(
                        new AppUser
                        {
                            Email = model.Email,
                            UserName = model.Username
                        }, password: model.Password);

                    if (res1.Succeeded)
                    {
                        var res2 = await _userService.Login(model.Username, model.Password, false);
                        if(res2.Succeeded)
                        {
                            //log
                            await _Ls.AddLog("N/A", $"{model.Username} successfully registered.", false);
                            //log

                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else ModelState.AddModelError("", "Cannot sign in user.");
                    }
                    else res1.Errors.ToList().ForEach(x => ModelState.AddModelError("",x.Description));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            //log
            await _Ls.AddLog("N/A", $"{model.Username} failed to register.", true);
            //log
            Response.StatusCode = ((int)HttpStatusCode.BadRequest);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? ReturnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _userService.Login(model.userName, model.Password, false);

                    if (res.Succeeded)
                    {
                            
                        if (!string.IsNullOrEmpty(ReturnUrl))
                        {
                            //log
                            await _Ls.AddLog("N/A", $"{model.userName} logged in successfully.", false);
                            //log
                            return Redirect(ReturnUrl);
                        }
                        else
                            return RedirectToAction("Index", "Home");
                    }
                    else ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            //log
            await _Ls.AddLog("N/A", $"{model.userName} failed to login.", true);
            //log
            Response.StatusCode = ((int)HttpStatusCode.BadRequest);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout(string? ReturnUrl)
        {
            try
            {
                await _userService.Logout();
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    //log
                    await _Ls.AddLog(this.User, "logged out.", false);
                    //log

                    return Redirect(ReturnUrl);
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Response.StatusCode = ((int)HttpStatusCode.InternalServerError);

                //log
                await _Ls.AddLog(this.User, "Failed to log out.", true);
                //log

                return Json(ex.Message);
            }
        }

        [HttpGet]
        public override UnauthorizedResult Unauthorized()
        {
            return Unauthorized();
        }

        #region Administration-related

        // GET: UserController
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Index(int pageNum = 1, string? nameFilter = null, string? roleFilter = null)
        {
            (var u, ViewBag.TotalPages) = await _userService.GetUsers(pageNum, nameFilter, roleFilter: null);
            List<UserViewModel> users = u.Select(x => UserMapper.UsertoVM(x)).ToList();

            ViewBag.Roles = _userService.GetAllRoles().Select(x =>
                new SelectListItem { Text = x, Value = x }).ToList();

            return View(users);
        }

        // GET: UserController/Details/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Details(ulong userId)
        {
            (AppUser user, string role) = await _userService.GetUserById(userId);
            UserViewModel userModel = UserMapper.UsertoVM(user);
            userModel.Role = role;
            return PartialView(userModel);
        }

        // GET: UserController/Create
        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Create()
        {
            ViewBag.roles = _userService.GetAllRoles().Select(x =>
                new SelectListItem { Text = x, Value = x });
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Create(UserViewModel user)
        {
            try
            {
                if (!_userService.GetAllRoles().Any(x => x == user.Role))
                    throw new Exception("Role does not exist!");

                if (ModelState.IsValid)
                {
                    IdentityResult res = await _userService.Register(UserMapper.VMtoUser(user), user.Role);
                    if (res.Succeeded)
                    {
                        //log
                        await _Ls.AddLog(this.User, $"Successfully created user {user.userName}.", false);
                        //log
                        return Ok(new { succ = true });
                    }
                    else
                        res.Errors.ToList().ForEach(x => ModelState.AddModelError("", x.Description));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            //log
            await _Ls.AddLog(this.User, $"Failed to create user {user.userName}.", true);
            //log

            Response.StatusCode = ((int)HttpStatusCode.BadRequest);
            ViewBag.roles = _userService.GetAllRoles().Select(x =>
                new SelectListItem { Text = x, Value = x });
            return PartialView(user);
        }

        // GET: UserController/Edit/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Edit(ulong userId)
        {
            try
            {
                ViewBag.roles = _userService.GetAllRoles().Select(x =>
                    new SelectListItem { Text = x, Value = x });
                (AppUser user, string role) = await _userService.GetUserById(userId);
                UserViewModel userModel = UserMapper.UsertoVM(user, role);
                return PartialView(userModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Edit(UserViewModel user)
        {
            try
            {
                if (!_userService.GetAllRoles().Any(x => x == user.Role))
                    throw new Exception("Role does not exist!");

                if (ModelState.IsValid)
                {
                    IdentityResult res = await _userService.EditUser(UserMapper.VMtoUser(user), user.Role);
                    if (res.Succeeded)
                    {
                        //log
                        await _Ls.AddLog(this.User, $"successfully edited user {user.userName}.", false);
                        //log

                        return PartialView(user);
                    }
                    else
                        res.Errors.ToList().ForEach(x => ModelState.AddModelError("", x.Description));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            //log
            await _Ls.AddLog(this.User, $"Failed to edit user {user.userName}.", true);
            //log

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            ViewBag.roles = _userService.GetAllRoles().Select(x =>
                new SelectListItem { Text = x, Value = x });
            return PartialView(user);
        }

        // GET: UserController/Delete/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> Delete(ulong userId)
        {
            return PartialView(UserMapper.UsertoVM((await _userService.GetUserById(userId)).Item1));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> DeletePost(ulong userId)
        {
            try
            {
                if (userId > 0)
                {
                    IdentityResult res = await _userService.DeleteUser((await _userService.GetUserById(userId)).Item1);
                    if (res.Succeeded)
                    {
                        //log
                        await _Ls.AddLog(this.User, $"successfully deleted user {userId}.", false);
                        //log

                        return PartialView();
                    }
                    else
                        res.Errors.ToList().ForEach(x => ModelState.AddModelError("", x.Description));
                }
                else
                {
                    ModelState.AddModelError("", "Menu ID cannot be null or zero.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            //log
            await _Ls.AddLog(this.User, $"Failed to delete user {userId}.", true);
            //log
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView(UserMapper.UsertoVM((await _userService.GetUserById(userId)).Item1));
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult changePassword(ulong userId)
        {
            return PartialView(new PasswordViewModel { 
                userId = userId,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult> changePassword(PasswordViewModel pass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityResult res = await _userService.setUserPassword(pass.userId, pass.Password);
                    if (res.Succeeded)
                    {
                        //log
                        await _Ls.AddLog(this.User, $"Successfully changed password of user {pass.userId}.", false);
                        //log

                        return PartialView(pass);
                    }
                    else
                        res.Errors.ToList().ForEach(x => ModelState.AddModelError("", x.Description));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            //log
            await _Ls.AddLog(this.User, $"Failed to change password of user {pass.userId}.", true);
            //log

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView(pass);
        }

        #endregion
    }
}
