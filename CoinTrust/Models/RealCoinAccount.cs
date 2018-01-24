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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required]
        public int user_id { get; set; }

        [ForeignKey("real_coin_type_id")]
        public RealCoinType RealCoinType { get; set; }

        [Required]
        public int real_coin_type_id { get; set;}

        // todo add regex to here
        [Required]
        public string address { get; set; }
    }
}