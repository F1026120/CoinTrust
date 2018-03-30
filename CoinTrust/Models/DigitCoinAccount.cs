using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CoinTrust.Models
{
    public class DigitCoinAccount
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DigitCoinAccountId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public virtual Account User { get; set; }

        [Required]
        public virtual DigitCoinType DigitCoinType { get; set; }
    }
}