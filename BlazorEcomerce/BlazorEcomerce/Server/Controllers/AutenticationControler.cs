using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                    Username = register.Username,
                    Email = register.Email,
                    PhoneNumber = register.PhoneNumber,
                }, register.Password);

            if (!result.Success)
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

        [HttpPost("changepasword/", Name = "changepasword"),Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePasword([FromBody] string newpasword)
        {
            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier); //Set while craeting the token. Geting the user id/

            var response = await _AutenticationService.ChangePassword(int.Parse(UserID), newpasword);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpPost("changenumber/", Name = "changenumber"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangeNumber([FromBody] string newnumber)
        {
            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier); //Set while craeting the token. Geting the user id/

            var response = await _AutenticationService.ChangeNumber(int.Parse(UserID), newnumber);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpPost("changeemail/", Name = "changeemail"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangeEmail([FromBody] string newemail)
        {
            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier); //Set while craeting the token. Geting the user id/

            var response = await _AutenticationService.ChangeEmail(int.Parse(UserID), newemail);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("getuserdata/", Name = "getuserdata"), Authorize]
        public async Task<ActionResult<ServiceResponse<User>>> GetUser()
        {
            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var response = await _AutenticationService.GetUserByID(int.Parse(UserID));

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("resetpasword/", Name = "resetpasword")]
        public async Task<ActionResult<ServiceResponse<bool>>> ResetPassword([FromBody] string email)
        {
            var response = await _AutenticationService.ResetPasword(email);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
