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
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Account User { get; set; }

        [Required]
        public int DigitCoinTypeId { get; set; }

        [ForeignKey("DigitCoinTypeId")]
        [Required]
        public DigitCoinType DigitCoinType { get; set; }

        // todo add regex to here
        [Key]
        [Required]
        public string Address { get; set; }
    }
}