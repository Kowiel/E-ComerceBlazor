using BlazorEcomerce.Client.IService;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using System.Net.Http.Json;

namespace BlazorEcomerce.Client.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly HttpClient _http;

        public AutenticationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<bool>> CHangePassword(ChangePaswordClass paswordClass)
        {
            var result = await _http.PostAsJsonAsync("api/autentication/changepasword", paswordClass.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<User>> FindUser() 
        { 
            var response = await _http.GetFromJsonAsync<ServiceResponse<User>>("api/autentication/getuserdata");
            return response;
        }

        public async Task<ServiceResponse<string>> Login(UserLogin userLogin)
        {
            var response = await _http.PostAsJsonAsync("api/autentication/login", userLogin);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserRegister userRegister)
        {
            var response = await _http.PostAsJsonAsync("api/autentication/register", userRegister);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}
