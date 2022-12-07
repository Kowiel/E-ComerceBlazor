using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomerce.Shared.Models
{
    public class UserRegister
    {
        [Required,StringLength(100,MinimumLength =3)]
        public string Username { get; set; } = String.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = String.Empty;
        [Compare("Password" ,ErrorMessage ="The passwords must be identical")]
        public string ConfirmPassword { get; set; } = String.Empty;
        [Required, Phone]
        public string PhoneNumber { get; set; } = String.Empty;
        
    }
}
