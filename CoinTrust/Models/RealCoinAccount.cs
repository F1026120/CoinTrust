using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoinTrust.Models
{
    public class RealCoinAccount
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RealCoinAccountId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public Account User { get; set; }

        [Required]
        public RealCoinType RealCoinType { get; set; }
    }
}