using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcomerce.Server.Controllers
{
    [Route("api/autentication")]
    [ApiController]
    public class AutenticationControler : ControllerBase
    {

        private readonly IAutenticationService _AutenticationService;

        public AutenticationControler(IAutenticationService AutenticationService)
        {
            _AutenticationService = AutenticationService;
        }

        [HttpPost("register/", Name = "RegisterAcount")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister register)
        {
            var result = await _AutenticationService.Register(
                new User
                {
                    Username= register.Username,
                    Email= register.Email,  
                    PhoneNumber= register.PhoneNumber,
                }, register.Password);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login/", Name = "LoginToAcount")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin login)
        {
            var result = await _AutenticationService.Login(login.Username, login.Password);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


    }
}
