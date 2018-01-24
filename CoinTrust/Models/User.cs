using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CoinTrust.Models
{
    public class User
    {
        [Key]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "手機號碼格式錯誤"), MaxLength(10, ErrorMessage = "手機號碼格式錯誤")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "手機號碼格式錯誤")]
        public string phone { get; set; }
        
        [Required]
        public bool certification { get; set; }

        [Required]
        public bool use_phone_authenticator { get; set; }

        [Required]
        public bool use_google_authenticator { get; set; }

        [Required]
        public DateTime create_at { get; set; }

        [Required]
        public DateTime update_at { get; set; }

        public ICollection<TransactionHistory> TransactionHistories { get; set; }
        
    }
}