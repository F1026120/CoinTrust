using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CoinTrust.Models
{
    public class Order
    {
        /// <summary>
        /// 每筆訂單代碼
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public Account Seller { get; set; }

        [Required]
        public DigitCoinType DigitCoinType { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        public float RemainQuantity { get; set; }

        [Required]
        public float MinQuantity { get; set; }

        [Required]        
        public string Address { get; set; }// todo add regex to here

        [Required]
        public OrderStatus OrderStatus { get; set; }
        
        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }

        public ICollection<Trade> Trade { get; set; }
    }
}