using BlazorEcomerce.Server.Data;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BlazorEcomerce.Server.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly DataContext _data;
        private readonly IConfiguration _configuration;

        public AutenticationService(DataContext data, IConfiguration configuration)
        {
            _data = data;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string Username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _data.Users.FirstOrDefaultAsync(x=>x.Username == Username);
            if(user == null)
            {
               response.Success= false;
               response.ReturnMesage = "Bad Username or Login";
            }

            else if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                response.Success = false;
                response.ReturnMesage = "Bad Username or Login";
            }
            else
            {
                response.Value= CreateToken(user);
                response.ReturnMesage = "Token";
                response.Success = true;
            }
            return response;

        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExistsEmail(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    ReturnMesage = "User with that Email already exists."
                };
            }

            if (await UserExistsUsername(user.Username))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    ReturnMesage = "User with that Username already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = "User"; 

            _data.Users.Add(user);
            await _data.SaveChangesAsync();

            return new ServiceResponse<int> { Value = user.Id, Success=true, ReturnMesage = "Registration successful!" };
        }

        public async Task<bool> UserExistsEmail(string Email)
        {
            if (await _data.Users.AnyAsync(user => user.Email.ToLower()
                 .Equals(Email.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UserExistsUsername(string Username)
        {
            if (await _data.Users.AnyAsync(user => user.Username.ToLower()
                 .Equals(Username.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async Task<ServiceResponse<User>> GetUserByID(int Id)
        {
            var User =await _data.Users.FirstOrDefaultAsync(x=> x.Id == Id);
            if (User == null)
            {
                return new ServiceResponse<User> { Value = null, Success = false, ReturnMesage = "Found no user" };
            }
            return new ServiceResponse<User> { Value = User, Success = true, ReturnMesage = "Found the user" };
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _data.SaveChangesAsync();

            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "Password has been changed." };
        }

        // Not in the Interface
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ServiceResponse<bool>> ChangeEmail(int userId, string newEmail)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }

            user.Email = newEmail;

            await _data.SaveChangesAsync();

            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "Email has been changed." };
        }

        public async Task<ServiceResponse<bool>> ChangeNumber(int userId, string newNumber)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }

            user.PhoneNumber = newNumber;

            await _data.SaveChangesAsync();
            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "PhoneNumber has been changed." };
        }

        public async Task<ServiceResponse<bool>> ResetPasword(string Email)
        {
            var user = await _data.Users.FirstOrDefaultAsync(x => x.Email == Email);
            if (user == null)
            {
                return new ServiceResponse<bool> { Value = false, Success = false, ReturnMesage = "Reset Email has not been sent no such user" };
            }

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("michal.patryk.urban@gmail.com"));
            email.To.Add(MailboxAddress.Parse($"{user.Email}"));
            email.Subject = $"Password Reset For {user.Username}";
            string password = GenerateRandomPassword(15);
            email.Body = new TextPart(TextFormat.Html) { Text = $"Your Reset Pasword is {password}" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp-relay.sendinblue.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("michal.patryk.urban@gmail.com", "hVCQS7qTLJDPtd4M");
            smtp.Send(email);
            smtp.Disconnect(true);

            var response =ChangePassword(user.Id, password);

            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = $"Reset Email has ben sent and {response.Result.ReturnMesage}" };
        }

        static string GenerateRandomPassword(int length)
        {
            const string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            char[] characters = new char[length];

            for (int i = 0; i < length; i++)
            {
                characters[i] = validCharacters[random.Next(validCharacters.Length)];
            }

            return new string(characters);
        }

        public async Task<ServiceResponse<bool>> ChangeLocalisation(int userId, string adres)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }
            user.Localisation= adres;

            await _data.SaveChangesAsync();

            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = $"adres has been changed to {adres}" };
        }
    }
}
