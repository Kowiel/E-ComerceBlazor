using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomerce.Shared.Models
{
    public class ChangeEmailClass
    {
        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Compare("Email", ErrorMessage = "The Emails must be identical")]
        public string ConfirmEmail { get; set; } = String.Empty;
    }
}
