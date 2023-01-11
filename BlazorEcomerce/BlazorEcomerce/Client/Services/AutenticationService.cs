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

        public async Task<ServiceResponse<bool>> ChangeLocaliation(UserLocalisation userLocalisation)
        {
            var Localisation = userLocalisation.PostalCode + " " + userLocalisation.Country + " " + userLocalisation.City + " " + userLocalisation.Adres;
            var result = await _http.PostAsJsonAsync("api/autentication/changelocalisation", Localisation);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
        public async Task<ServiceResponse<bool>> ChangeEmail(ChangeEmailClass changeEmail)
        {
            var result = await _http.PostAsJsonAsync("api/autentication/changeemail", changeEmail.Email);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
        public async Task<ServiceResponse<bool>> ResetPassword(ChangeEmailClass changeEmail)
        {
            var result = await _http.PostAsJsonAsync("api/autentication/resetpasword", changeEmail.Email);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<bool>> CHangePassword(ChangePaswordClass paswordClass)
        {
            var result = await _http.PostAsJsonAsync("api/autentication/changepasword", paswordClass.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<bool>> ChangePhoneNumber(ChangePhoneNumberClass changePhone)
        {
            var result = await _http.PostAsJsonAsync("api/autentication/changenumber", changePhone.PhoneNumber);
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
