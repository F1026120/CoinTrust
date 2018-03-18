using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.Models
{
    public class RealCoinFund
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RealCoinFundId { get; set; }
        
        [Required]
        public Account User { get; set; }

        [Required]
        public RealCoinType RealCoinType { get; set; }

        [Required]
        public CoinStatus CoinStatus { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}