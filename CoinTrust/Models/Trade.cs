using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.Models
{
    public class Trade
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Required]
        public int id { get; set; }

        [ForeignKey("order_id")] // 這邊注意 user_id雖然是從Order拿 但是值仍是在User
        public User seller { get; set; }

        [Required]
        public int order_id { get; set; }

        [ForeignKey("buyer_id")]
        public User buyer { get; set; }

        [Required]
        public int buyer_id { get; set; }

        [Required]
        public float quantity { get; set; }

        [Required]
        public float price { get; set; }

        [Required]
        public TradeStatus trade_status { get; set; }

        [Required]
        public DateTime create_at { get; set; }
    }
}