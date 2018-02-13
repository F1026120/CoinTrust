using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.ViewModels
{
    public class ResetPassword
    {
        [Key]
        [EmailAddress]
        public string email { get; set; }

        public string old_password { get; set; }

        public string password { get; set; }

        [NotMapped]
        [Compare("password",ErrorMessage = "密碼不一致")]
        public string confirm_password { get; set; }
    }
}