using MatcherWebApi.Interfaces;
using System.Collections.Generic;

namespace MatcherWebApi.Classes
{
    public class TradeManager : ITradeManager
    {
        #region Private Declarations

        private IList<ITrade> marketTrades = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// List of trades
        /// </summary>
        public IList<ITrade> MarketTrades
        {
            get => marketTrades ?? (marketTrades = new List<ITrade>());
            set => marketTrades = value;
        }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// Constructor of the TradeManager class.
        /// </summary>
        public TradeManager()
        { }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Add a trade to the manager.
        /// </summary>
        /// <param name="trade">The trade to add.</param>
        public void Add(ITrade trade)
        {
            MarketTrades.Add(trade);
        }

        /// <summary>
        /// Add the trades to the Trade Manager.
        /// </summary>
        /// <param name="trades">The trades to add.</param>
        public void Add(IList<ITrade> trades)
        {
            foreach (var trade in trades)
            {
                Add(trade);
            }
        }

        #endregion Methods
    }
}