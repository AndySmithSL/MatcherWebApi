using System.Collections.Generic;

namespace MatcherWebApi.Interfaces
{
    public interface ITradeManager
    {
        /// <summary>
        /// List of trades
        /// </summary>
        IList<ITrade> MarketTrades { get; set; }

        /// <summary>
        /// Add a trade to the manager.
        /// </summary>
        /// <param name="trade">The trade to add.</param>
        void Add(ITrade trade);

        /// <summary>
        /// Add the trades to the Trade Manager.
        /// </summary>
        /// <param name="trades">The trades to add.</param>
        void Add(IList<ITrade> trades);

    }
}