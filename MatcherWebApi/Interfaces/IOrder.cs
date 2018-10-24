using MatcherWebApi.Enumerators;
using System;

namespace MatcherWebApi.Interfaces
{
    public interface IOrder
    {
        /// <summary>
        /// The account of the order
        /// </summary>
        IAccount Account { get; set; }

        /// <summary>
        /// The quantity of the order
        /// </summary>
        int? Quantity { get; set; }

        /// <summary>
        /// The price of the order
        /// </summary>
        decimal? Price { get; set; }

        /// <summary>
        /// The value of the order
        /// </summary>
        decimal? Value { get; }

        /// <summary>
        /// Is the order a buy or sell
        /// </summary>
        OrderType? OrderType { get; set; }

        /// <summary>
        /// The date and time of the order
        /// </summary>
        DateTime? OrderDate { get; set; }

        /// <summary>
        /// Clone the order
        /// </summary>
        IOrder Clone { get; }

    }
}