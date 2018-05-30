using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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
        [DisplayName("購買數量")]
        public double Quantity { get; set; }

        [Required]
        [DisplayName("訂單狀態")]
        public TradeStatus TradeStatus { get; set; }

        [Required]
        [DisplayName("訂單建立時間")]
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// 買家的錢包地址
        /// </summary>
        [Required]
        [DisplayName("買家錢包地址")]
        public string BuyerAddress { get; set; }

        public string TxHash { get; set; }
    }
}