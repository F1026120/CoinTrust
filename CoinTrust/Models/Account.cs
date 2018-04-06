using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CoinTrust.Models
{
    public class Account
    {
        [Key]
        [DisplayName("使用者信箱")]
        [Required]
        [EmailAddress]
        public string AccountId { get; set; }

        [Required]
        [DisplayName("密碼")]
        public string Password { get; set; }

        [NotMapped]
        //[Compare("Password", ErrorMessage = "密碼不一致")]
        [DisplayName("確認密碼")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "手機號碼格式錯誤"), MaxLength(10, ErrorMessage = "手機號碼格式錯誤")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "手機號碼格式錯誤")]
        [DisplayName("手機號碼")]
        public string Phone { get; set; }


        public bool Certified { get; set; }


        public string CertificationCode { get; set; }

        [Required]
        public bool UsePhoneAuthenticator { get; set; }

        [Required]
        public bool UseGoogleAuthenticator { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }
    }
}