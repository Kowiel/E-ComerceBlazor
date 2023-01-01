using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomerce.Shared.Models
{
    public class ChangePhoneNumberClass
    {
        [Required, Phone]
        public string PhoneNumber { get; set; } = String.Empty;
        [Compare("PhoneNumber", ErrorMessage = "The PhoneNumbers must be identical")]
        public string ConfirmPhoneNumber { get; set; } = String.Empty;
    }
}

