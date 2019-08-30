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

        [Required(ErrorMessage = "New Password is required")]
        [Display(Name = "New Password:")]
        [DataType(DataType.Password)]
        public string NewPassword{ get; set; }
    }
}