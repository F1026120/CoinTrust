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
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionHistoryId { get; set; }

        /// <summary>
        /// the primary key of User table
        /// </summary>
        [Required]
        public Account User { get; set; }
        
        /// <summary>
        /// 真實貨幣幣種
        /// </summary>
        [Required]
        public RealCoinType RealCoinType { get; set; }
        
        /// <summary>
        /// 轉帳金額
        /// </summary>
        [Required]
        public double Amount { get; set; }
        
        /// <summary>
        /// 交易狀態
        /// </summary>
        [Required]
        public TransactionStatus TransactionStatus { get; set; }
        
        /// <summary>
        /// 轉帳時間
        /// </summary>
        [Required]
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        [Required]
        public DateTime UpdateAt { get; set; }
    }
}