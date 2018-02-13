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
        public int Id { get; set; }

        [Required]
        public string SellerId { get; set; }

        [ForeignKey("seller_id")]
        public Account User { get; set; }

        [Required]
        public int DigitCoinTypeId { get; set; }

        [ForeignKey("digit_coin_type_id")]
        public DigitCoinType DigitCoinType { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        public float RemaiQuantity { get; set; }

        [Required]
        public float MinQuantity { get; set; }

        [Required]        
        public string Address { get; set; }// todo add regex to here
        /*
        [Required]
        public ICollection<OrderStatus> order_status_id { get; set; }
        [ForeignKey("order_status_id")]
        */
        public OrderStatus OrderStatusId { get; set; }
        
        public DateTime create_at { get; set; }
    }
}