using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinTrust.Models
{
    public enum TransactionStatus
    {
        Successed,
        Pending,
        Failed
    }

    public enum TradeStatus
    {
        Filled,
        Rejected,
        Canceled
    }
    
    public enum OrderStatus
    {
        New,
        PartialFilled,
        Filled,
        Expired,
        Rejected,
        Canceled
    }

    public enum CoinStatus
    {
        Free,
        Pending,
        Freezed
    }
}