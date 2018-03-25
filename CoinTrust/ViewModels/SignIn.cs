using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CoinTrust.ViewModels
{
    public class SignIn
    {
        [EmailAddress]
        [Required]
        [DisplayName("信箱")]
        public string AccountId { get; set; }

        [Required]
        [DisplayName("密碼")]
        public string password { get; set; }

    }
}