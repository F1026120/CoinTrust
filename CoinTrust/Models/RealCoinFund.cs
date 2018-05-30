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
        public string AccoundId { get; set; }


        //public virtual Account User { get; set; }

        public virtual RealCoinType RealCoinType { get; set; }

        [Required]
        public CoinStatus CoinStatus { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}