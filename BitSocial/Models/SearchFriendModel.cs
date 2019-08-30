using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitSocial.Models
{
    public class SearchFriendModel
    {

        [Required(ErrorMessage = "The email field is required!")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Friends Email Address :")]
        public string Email { get; set; }
    }
}