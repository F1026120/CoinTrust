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
        public int Id { get; set; }

        [Required]
        public Account Seller { get; set; }

        [Required]
        public Account Buyer { get; set; }
        
        [Required]
        public Order Order { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public TradeStatus TradeStatus { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }
    }
}