using AuthAPI.Models;

namespace AuthAPI.Interfaces
{
    public interface IAuthJWTService
    {
        bool IsAuthenticated(UserViewModel user, out string token);
    }
}
