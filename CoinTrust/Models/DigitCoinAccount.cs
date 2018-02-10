using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoinTrust.Models
{
    public class DigitCoinAccount
    {
        [Required]
        public string user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required]
        public int digit_coin_type_id { get; set; }

        [ForeignKey("digit_coin_type_id")]
        [Required]
        public DigitCoinType DigitCoinType { get; set; }

        // todo add regex to here
        [Key]
        [Required]
        public string address { get; set; }
    }
}