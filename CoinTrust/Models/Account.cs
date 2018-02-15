using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.Models
{
    public class Account
    {
        [Key]
        [Required]
        [EmailAddress]
        public string AccountId { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "密碼不一致")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "手機號碼格式錯誤"), MaxLength(10, ErrorMessage = "手機號碼格式錯誤")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "手機號碼格式錯誤")]
        public string Phone { get; set; }
        
        [Required]
        public bool Certification { get; set; }

        [Required]
        public bool UsePhoneAuthenticator { get; set; }

        [Required]
        public bool UseGoogleAuthenticator { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }

        public ICollection<TransactionHistory> TransactionHistory { get; set; }

        public ICollection<DigitCoinAccount> DigitCoinAccount { get; set; }

        public ICollection<RealCoinAccount> RealCoinAccount { get; set; }

        public ICollection<Order> Order { get; set; }

        public ICollection<Trade> Trade { get; set; }

        public ICollection<LoginHistory> LoginHistory { get; set; }

        public ICollection<RealCoinFund> RealCoinFund { get; set; }
    }
}