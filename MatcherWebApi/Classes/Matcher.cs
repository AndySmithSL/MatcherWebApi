using MatcherWebApi.Enumerators;
using MatcherWebApi.Interfaces;
using MatcherWebApi.Models;
using System;

namespace MatcherWebApi.Classes
{
    public class Matcher : IMatcher
    {
        #region Private Declarations

        private MatcherContext context = null;
        private IOrderManager orderManager = null;
        private ITradeManager tradeManager = null;
        private IAccountManager accountManager = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// The database context to retrieve the data
        /// </summary>
        public MatcherContext Context
        {
            get => context ?? throw new NullReferenceException("The database context has not been set.");
            set => context = value;
        }

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
            get => accountManager ?? (accountManager = new AccountManager(Context));
            set => accountManager = value;
        }

        #endregion Public Properties

        #region Contructor

        /// <summary>
        /// The constructor of the Matcher class.
        /// </summary>
        public Matcher()
        { }

        /// <summary>
        /// The constructor of the Matcher class.
        /// </summary>
        /// <param name="context">The database context to retrieve the data.</param>
        public Matcher(MatcherContext context)
        {
            Context = context;
        }

        #endregion Contructor

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