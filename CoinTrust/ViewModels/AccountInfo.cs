using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.ViewModels
{
    public class AccountInfo
    {
        public Account User { get; set; }

        public List<LogonHistory> LogonHistory { get; set; }
    }
}