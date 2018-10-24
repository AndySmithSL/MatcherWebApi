using System;

namespace MatcherWebApi.Interfaces
{
    public interface ITrade
    {
        /// <summary>
        /// 
        /// </summary>
        IOrder NewOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IOrder ExistingOrder { get; set; }

        /// <summary>
        /// Account of the Buyer
        /// </summary>
        IAccount Buyer { get; }

        /// <summary>
        /// Account of the Seller
        /// </summary>
        IAccount Seller { get; }

        /// <summary>
        /// Quantity of the trade
        /// </summary>
        int? Quantity { get; }

        /// <summary>
        /// Price of the trade
        /// </summary>
        decimal? Price { get; }

        /// <summary>
        /// Overall value of the trade.
        /// </summary>
        decimal? Value { get; }

        /// <summary>
        /// The date and time the trade was created.
        /// </summary>
        DateTime? TradeDate { get; set; }
    }
}