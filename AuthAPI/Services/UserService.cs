using AuthAPI.Interfaces;
using AuthAPI.Models;

namespace AuthAPI.Services;

public class UserService : IUserService
{
    public bool ValidateUser(UserViewModel userViewModel)
    {
        return userViewModel.UserName == "robson" && userViewModel.Password == "1010";
    }
}
