using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.Models
{
    public class RealCoinFunds
    {
        [Required]
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required]
        public string real_coin_type_id { get; set; }

        [Required]
        [ForeignKey("real_coin_type_id")]
        public RealCoinType realCoinType { get; set; }

        [Required]
        public CoinStatus coin_status { get; set; }

        [Required]
        public float amount { get; set; }
    }
}