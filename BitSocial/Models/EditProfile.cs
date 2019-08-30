using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitSocial.Models
{
    public class EditProfile
    {
        [Required(ErrorMessage = "The name field is required!")]
        [DisplayName("Name :")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The surname field is required!")]
        [DisplayName("Surname :")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The email field is required!")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address :")]
        public string Email { get; set; }
    }
}