using BlazorEcomerce.Server.Data;
using BlazorEcomerce.Server.IServices;
using BlazorEcomerce.Shared.Models;
using BlazorEcomerce.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BlazorEcomerce.Server.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly DataContext _data;
        public AutenticationService(DataContext data)
        {
            _data = data;
        }
        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    ReturnMesage = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _data.Users.Add(user);
            await _data.SaveChangesAsync();

            return new ServiceResponse<int> { Value = user.Id, ReturnMesage = "Registration successful!" };
        }

        public async Task<bool> UserExists(string Email)
        {
            if (await _data.Users.AnyAsync(user => user.Email.ToLower()
                 .Equals(Email.ToLower())))
            {
                return true;
            }
            return false;
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
    }
}
