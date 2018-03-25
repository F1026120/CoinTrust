using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.ViewModels
{
    public class AccountInfo
    {
        [Key]
        public Account User { get; set; }

        public List<LoginHistory> LoginHistory { get; set; }

        public RealCoinAccount RealCoinAccount { get; set; }

        public List<DigitCoinAccount> DigitCoinAccount { get; set; }

        public RealCoinFund RealCoinFund { get; set; }
    }
}