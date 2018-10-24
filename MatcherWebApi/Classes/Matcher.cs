using MatcherWebApi.Enumerators;
using MatcherWebApi.Interfaces;
using System;

namespace MatcherWebApi.Classes
{
    public class Matcher : IMatcher
    {
        #region Private Declarations

        private IOrderManager orderManager = null;
        private ITradeManager tradeManager = null;
        private IAccountManager accountManager = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// Object for managing the orders.
        /// </summary>
        public IOrderManager OrderManager
        {
            get => orderManager ?? (orderManager = new OrderManager());
            set => orderManager = value;
        }

        /// <summary>
        /// Object for managing the trades.
        /// </summary>
        public ITradeManager TradeManager
        {
            get => tradeManager ?? (tradeManager = new TradeManager());
            set => tradeManager = value;
        }

        /// <summary>
        /// Object for managing the accounts.
        /// </summary>
        public IAccountManager AccountManager
        {
            get => accountManager ?? (accountManager = new AccountManager());
            set => accountManager = value;
        }

        #endregion Public Properties

        #region Methods

        /// <summary>
        /// Place the order.
        /// </summary>
        /// <param name="accountNumber">The account number of the order.</param>
        /// <param name="quantity">The quantity of the order.</param>
        /// <param name="price">The price of the order.</param>
        /// <param name="orderType">The type of the order.</param>
        public void PlaceOrder(string accountNumber, int quantity, decimal price, OrderType orderType)
        {
            IAccount account = AccountManager.FindAccountByAccountNumber(accountNumber);

            if (account == null)
            {
                throw new ApplicationException("Cannot find the account, unable to place the order.");
            }

            TradeManager.Add(OrderManager.PlaceOrder(account, quantity, price, orderType));
        }

        #endregion Methods

    }
}