using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoinTrust.Models
{
    
    public class TransactionHistory
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        /// <summary>
        /// the primary key of User  table
        /// </summary>
        [Required]
        public string user_email_ref { get; set; }

        /// <summary>
        /// 用戶
        /// </summary>
        [ForeignKey("user_email_ref")]
        public User User { get; set; }
        
        /// <summary>
        /// the primary key of RealCoinType table
        /// </summary>
        [Required]
        public int real_coin_type_id { get; set; }

        /// <summary>
        /// 真實貨幣幣種
        /// </summary>
        [ForeignKey("real_coin_type_id")]
        public RealCoinType RealCoinType { get; set; }
        
        /// <summary>
        /// 轉帳金額
        /// </summary>
        [Required]
        public float amount { get; set; }
        
        /// <summary>
        /// 交易狀態
        /// </summary>
        [Required]
        public TransactionStatus transaction_status { get; set; }
        
        /// <summary>
        /// 轉帳時間
        /// </summary>
        [Required]
        public DateTime create_at { get; set; }
    }
}