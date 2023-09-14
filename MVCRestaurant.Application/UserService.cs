using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(string username, string password, bool rememberMe)
        {
            AppUser toLogin = await this.GetUserByName(username);
            if(toLogin == null)
            {
                return SignInResult.Failed;
            }
            var res = await _signInManager.CheckPasswordSignInAsync(toLogin, password, false);
            if(!res.Succeeded)
            {
                return res;
            }
            var customClaims = new List<Claim> { new Claim("AltKey", toLogin.AltKey.ToString()) };
            await _signInManager.SignInWithClaimsAsync(toLogin, rememberMe, customClaims);

            return SignInResult.Success;
        }

        public async Task<IdentityResult> Register(AppUser user, string role = "Customer")
        {
            var res1 = await _userManager.CreateAsync(user);
            if(res1.Succeeded)
            {
                var res2 = await this.AddRoleToUser(user, role);
                if (!res2.Succeeded)
                    await this.RemoveRoleFromUser(user, role);
                return res2;
            }
            return res1;
        }

        public async Task<IdentityResult> Register(AppUser user, string password, string role = "Customer")
        {
            var res1 = await _userManager.CreateAsync(user, password);
            if (res1.Succeeded)
            {
                var res2 = await this.AddRoleToUser(user, role);
                if (!res2.Succeeded)
                    await _userManager.DeleteAsync(user);
                return res2;
            }
            return res1;
        }

        public async Task Logout(/* Current User Id */)
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> DeleteUser(AppUser user)
        {
            if (user.AltKey == 1)
                throw new Exception("--invalid operation--");

            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> EditUser(AppUser user, string role)
        {
            if (user.AltKey == 1)
                throw new Exception("--invalid operation--");

            (AppUser newUser, string previousRole) = await this.GetUserById(user.AltKey);

            //string previousRole = (await this.GetUserRoles(newUser.AltKey)).Single();

            var res1 = await this.RemoveRoleFromUser(newUser, previousRole);

            if(!res1.Succeeded)
            {
                return res1;
            }

            var res2 = await this.AddRoleToUser(newUser, role);

            if(!res2.Succeeded)
            { 
                await this.AddRoleToUser(newUser, previousRole);
                return res2;
            }

            newUser.UserName = user.UserName;
            newUser.Address = user.Address;
            newUser.Email = user.Email;
            newUser.Latitude = user.Latitude;
            newUser.Longitude = user.Longitude;
            var res3 = await _userManager.UpdateAsync(newUser);

            if(!res3.Succeeded)
            {
                await this.RemoveRoleFromUser(newUser, role);
                await this.AddRoleToUser(newUser, previousRole);
                return res3;
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> setUserPassword(ulong userId, string password)
        {
            if (userId == 1)
                throw new Exception("--invalid operation--");

            AppUser newUser = (await this.GetUserById(userId)).Item1;
            newUser.PasswordHash = _userManager.PasswordHasher.HashPassword(newUser, password);
            return await _userManager.UpdateAsync(newUser);
        }

        // System.Security.Claims.ClaimsPrincipal currentUser = this.User; in controller
        public async Task<AppUser> GetCurrentUser(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }

        // System.Security.Claims.ClaimsPrincipal currentUser = this.User; in controller
        //current user id is also retrievable from controller (using claims)
        public string GetCurrentUserId(ClaimsPrincipal user)
        {
            return _userManager.GetUserId(user);
        }

        public async Task<(List<AppUser>, int)> GetUsers(int PageNum, string? nameFilter, string? roleFilter = null)
        {
            bool hasNameFilter = !string.IsNullOrEmpty(nameFilter);
            bool hasRoleFilter = !string.IsNullOrEmpty(roleFilter);
            IQueryable<AppUser> users = null; //_userManager.Users.Where(x => x.AltKey != 1);

            //4 ifs
            if (!hasNameFilter && !hasRoleFilter)
            {
                users = _userManager.Users.Where(x => x.AltKey != 1);
            }
            else if (hasNameFilter && !hasRoleFilter)
            {
                users = _userManager.Users.Where(x => x.AltKey != 1 
                && x.NormalizedUserName.Contains(nameFilter.ToUpper()));
            }
            //else if (!hasNameFilter && hasRoleFilter)
            //{
            //    users = (await _userManager.GetUsersInRoleAsync(roleFilter)).ToList();
            //}
            //else //if (hasNameFilter && hasRoleFilter)
            //{
            //    users = _userManager.Users.Where(x => x.AltKey != 1 && x.NormalizedUserName.Contains(nameFilter.ToUpper()));
            //}

            return (await users.Page(10, PageNum).ToListAsync(), (int)(Math.Ceiling(await users.CountAsync()/10f)));
        }

        public async Task<(AppUser,string)> GetUserById(ulong userId)
        {
            if (!await _userManager.Users.AnyAsync(x => x.AltKey == userId))
            {
                throw new Exception("User Id doesn't exist.");
            }

            AppUser user = await _userManager.Users.Where(x => x.AltKey == userId).SingleAsync();
            

            return (user, (await _userManager.GetRolesAsync(user)).First()) ;
        }


        public async Task<AppUser> GetUserByName(string name)
        {
            return await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == name);
        }

        #region Roles

        public List<string> GetAllRoles()
        {
            return Enum.GetNames((typeof(RolesEnum))).Except(
                new List<string> { RolesEnum.SuperAdmin.ToString() }).ToList();
        }

        //get user role
        //public async Task<List<string>> GetUserRoles(ulong Id)
        //{
        //    return (await _userManager.GetRolesAsync(await GetUserById(Id))).ToList();
        //}

        //add role to user
        public async Task<IdentityResult> AddRoleToUser(AppUser user, string role)
        {
            if (GetAllRoles().Contains(role))
            {
                return await _userManager.AddToRoleAsync(user, role);
            }
            else
                throw new Exception("Role does not exist!");
        }

        //remove user from role
        public async Task<IdentityResult> RemoveRoleFromUser(AppUser user, string role)
        {
            if (user.AltKey == 1)
                throw new Exception("--invalid operation--");

            return await _userManager.RemoveFromRoleAsync(user, role);
        }

        #endregion
    }
}
