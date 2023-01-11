using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;

namespace BlazorEcomerce.Client.IService
{
    public interface IAutenticationService
    {
        Task<ServiceResponse<int>> Register(UserRegister userRegister);
        Task<ServiceResponse<string>> Login(UserLogin userLogin); 

        Task<ServiceResponse<bool>> CHangePassword(ChangePaswordClass paswordClass);
        Task<ServiceResponse<bool>> ResetPassword(ChangeEmailClass changeEmail);
        Task<ServiceResponse<bool>> ChangeEmail(ChangeEmailClass changeEmail);
        Task<ServiceResponse<bool>> ChangePhoneNumber(ChangePhoneNumberClass changePhone);
        Task<ServiceResponse<bool>> ChangeLocaliation(UserLocalisation userLocalisation);
        Task<ServiceResponse<User>> FindUser();
    }
}
