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
        public string id { get; set; }

        [Required]
        public int seller_id { get; set; }

        [ForeignKey("seller_id")]
        public User User { get; set; }

        [ForeignKey("DigitCoinType")]
        [Required]
        public string digit_coin_type_id { get; set; }

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

        [ForeignKey("OrderStatus")]
        [Required]
        public int order_status_id { get; set; }
        
        public DateTime create_at { get; set; }
    }
}