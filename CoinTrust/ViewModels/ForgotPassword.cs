using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CoinTrust.ViewModels
{
    public class ForgotPassword
    {
        [Key]
        [EmailAddress]
        [DisplayName("信箱")]
        public string email { get; set; }


    }
}