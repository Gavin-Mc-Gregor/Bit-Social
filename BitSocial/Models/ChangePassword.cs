using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitSocial.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage ="Old Password is required")]
        [Display(Name ="Old Password:")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [RegularExpression(@"^(?=.{6,}$)(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\W).*$",
                           ErrorMessage = "Password must contain: atleast one number, atleast one special character, and both uppercase and lowwercase.")]
        [Required(ErrorMessage = "New Password is required")]
        [Display(Name = "New Password:")]
        [DataType(DataType.Password)]
        public string NewPassword{ get; set; }
    }
}