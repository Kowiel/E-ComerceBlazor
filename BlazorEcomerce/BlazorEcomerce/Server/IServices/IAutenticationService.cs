using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using BlazroEcomerce.Shared.Models;

namespace BlazorEcomerce.Server.IServices
{
    public interface IAutenticationService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> UserExistsEmail(string Email);
        Task<bool> UserExistsUsername(string Username);
        Task<ServiceResponse<string>> Login(string Username, string password);
        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
        Task<ServiceResponse<User>> GetUserByID(int Id);

    }
}
