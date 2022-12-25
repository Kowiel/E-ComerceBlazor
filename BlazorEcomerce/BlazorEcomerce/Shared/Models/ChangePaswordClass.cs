using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomerce.Shared.Models
{
    public class ChangePaswordClass
    {
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = String.Empty;
        [Compare("Password", ErrorMessage = "The passwords must be identical")]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}
