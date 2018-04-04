using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CoinTrust.Models
{
    public class Order
    {
        /// <summary>
        /// 每筆訂單代碼
        /// </summary>
        [Key]
        [DisplayName("訂單ID")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        /// <summary>
        /// Order賣家
        /// </summary>
        [Required]
        public virtual Account Seller { get; set; }

        [Required]
        public virtual DigitCoinType DigitCoinType { get; set; }

        /// <summary>
        /// 數位貨幣單價
        /// </summary>
        [Required]
        [DisplayName("單價")]
        public double Price { get; set; }

        /// <summary>
        /// 數位貨幣數量
        /// </summary>
        [Required]
        [DisplayName("數量")]
        public double Quantity { get; set; }

        /// <summary>
        /// 數位貨幣剩餘數量
        /// </summary>
        [Required]
        [DisplayName("剩餘數量")]
        public double RemainQuantity { get; set; }

        /// <summary>
        /// 最小購買數量
        /// </summary>
        [Required]
        [DisplayName("最小購買數量")]
        public double MinQuantity { get; set; }

        /// <summary>
        /// 賣家數位貨幣地址
        /// </summary>
        [Required]        
        [DisplayName("錢包地址")]
        public string Address { get; set; }// todo add regex to here

        [Required]
        [DisplayName("訂單狀態")]
        public OrderStatus OrderStatus { get; set; }
        
        [Required]
        [DisplayName("訂單建立時間")]
        public DateTime CreateAt { get; set; }

        [Required]
        [DisplayName("最後更新時間")]
        public DateTime UpdateAt { get; set; }
    }
}