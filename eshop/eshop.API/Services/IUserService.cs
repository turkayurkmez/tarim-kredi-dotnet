using eshop.Domain;

namespace eshop.API.Services
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
    }
}