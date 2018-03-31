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
        /// <summary>
        /// 交易完成
        /// </summary>
        finished,
        /// <summary>
        /// 交易中
        /// </summary>
        Trading,
        /// <summary>
        /// 交易取消
        /// </summary>
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