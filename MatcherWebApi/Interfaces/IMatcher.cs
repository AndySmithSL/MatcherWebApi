using MatcherWebApi.Enumerators;
using MatcherWebApi.Models;

namespace MatcherWebApi.Interfaces
{
    public interface IMatcher
    {
        /// <summary>
        /// The database context to retrieve the data
        /// </summary>
        MatcherContext Context { get; set; }

        /// <summary>
        /// Object for managing the orders.
        /// </summary>
        IOrderManager OrderManager { get; set; }

        /// <summary>
        /// Object for managing the trades.
        /// </summary>
        ITradeManager TradeManager { get; set; }

        /// <summary>
        /// Object for managing the accounts.
        /// </summary>
        IAccountManager AccountManager { get; set; }

        /// <summary>
        /// Place the order.
        /// </summary>
        /// <param name="accountNumber">The account number of the order.</param>
        /// <param name="quantity">The quantity of the order.</param>
        /// <param name="price">The price of the order.</param>
        /// <param name="orderType">The type of the order.</param>
        void PlaceOrder(string accountNumber, int quantity, decimal price, OrderType orderType);

    }
}