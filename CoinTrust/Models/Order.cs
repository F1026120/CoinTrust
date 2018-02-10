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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string seller_id { get; set; }

        [ForeignKey("seller_id")]
        public User User { get; set; }

        [Required]
        public int digit_coin_type_id { get; set; }

        [ForeignKey("digit_coin_type_id")]
        public DigitCoinType digitCoinType { get; set; }

        [Required]
        public float price { get; set; }

        [Required]
        public float quantity { get; set; }

        [Required]
        public float remain_quantity { get; set; }

        [Required]
        public float min_quantity { get; set; }

        [Required]        
        public string address { get; set; }// todo add regex to here
        /*
        [Required]
        public ICollection<OrderStatus> order_status_id { get; set; }
        [ForeignKey("order_status_id")]
        */
        public OrderStatus order_status_id { get; set; }
        
        public DateTime create_at { get; set; }
    }
}