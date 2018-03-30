using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CoinTrust.Models
{
    public class RealCoinAccount
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RealCoinAccountId { get; set; }

        [DisplayName("銀行名稱")]
        [Required]
        public string BankName { get; set; }


        [DisplayName("銀行帳號")]
        [Required]
        public string Address { get; set; }

        [Required]
        public virtual Account User { get; set; }

        [Required]
        public virtual RealCoinType RealCoinType { get; set; }
    }
}