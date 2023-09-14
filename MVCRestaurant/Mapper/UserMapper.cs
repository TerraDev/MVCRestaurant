using MVCRestaurant.Models;
using MVCRestaurant.ViewModels.User;

namespace MVCRestaurant.Mapper
{
    public static class UserMapper
    {
        internal static UserViewModel UsertoVM(AppUser user, string? Role=null)
        {
            return new UserViewModel(user.AltKey)
            {
                userName = user.UserName,
                Email = user.Email,
                PasswordSet = user.PasswordHash != null,
                //Address = user.Address,
                //Latitude = user.Latitude,
                //Longitude = user.Longitude,
                Role = Role
            };
        }

        internal static AppUser VMtoUser(UserViewModel userModel)
        {
            return new AppUser()
            {
                UserName = userModel.userName,
                Email = userModel.Email,
                //Address = userModel.Address,
                //Latitude = userModel.Latitude,
                //Longitude = userModel.Longitude,
                AltKey = userModel.userId.GetValueOrDefault(),
                // set roles in controller/service
            };
        }
    }
}
