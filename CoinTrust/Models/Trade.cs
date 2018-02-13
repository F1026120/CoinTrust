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
        /// 每筆交易代碼
        /// </summary>
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public string seller_id { get; set; }

        [ForeignKey("seller_id")]
        public virtual Account seller { get; set; }

        [Required]
        public string buyer_id { get; set; }

        [ForeignKey("buyer_id")]
        public virtual Account buyer { get; set; }
        
        [Required]
        public string order_id { get; set; }

        [ForeignKey("order_id")]
        public virtual Order order { get; set; }

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