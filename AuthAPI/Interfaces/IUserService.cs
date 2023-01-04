using AuthAPI.Models;

namespace AuthAPI.Interfaces
{
    public interface IUserService
    {
        bool ValidateUser(UserViewModel userViewModel);
    }
}