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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TradeId { get; set; }

        // 這邊也許與Order的Seller有潛在的問題
        [Required]
        public virtual Account Buyer { get; set; }
        
        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public TradeStatus TradeStatus { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// 買家的錢包地址
        /// </summary>
        [Required]
        public string BuyerAddress { get; set; }
    }
}