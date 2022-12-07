using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;

namespace BlazorEcomerce.Server.IServices
{
    public interface IAutenticationService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> UserExists(string Email);

    }
}
