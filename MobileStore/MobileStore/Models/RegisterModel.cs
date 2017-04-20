using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileStore.Models
{
    public class RegisterModel{
        [DataType("Email"), Required]
        public string Email { get; set; }
        [Required, DataType("Password")]
        public string Password { get; set; }
        [Required, DataType("Password")]
        public string ConfirmPassword { get; set; }

    }
}