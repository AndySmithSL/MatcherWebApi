using MatcherWebApi.Enumerators;
using MatcherWebApi.Interfaces;
using System;

namespace MatcherWebApi.Classes
{
    public class Trade : ITrade
    {
        #region Private Declarations

        private IOrder newOrder = null;
        private IOrder existingOrder = null;
        private decimal? price = null;
        private DateTime? tradeDate = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public IOrder NewOrder
        {
            get => newOrder ?? throw new NullReferenceException("The New Order has not been set.");
            set => newOrder = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public IOrder ExistingOrder
        {
            get => existingOrder ?? throw new NullReferenceException("The Existing Order has not been set.");
            set => existingOrder = value;
        }

        /// <summary>
        /// Account of the Buyer
        /// </summary>
        public IAccount Buyer
        {
            get => NewOrder.OrderType == OrderType.BUY ? NewOrder.Account : ExistingOrder.Account;
        }

        /// <summary>
        /// Account of the Seller
        /// </summary>
        public IAccount Seller
        {
            get => NewOrder.OrderType == OrderType.SELL ? NewOrder.Account : ExistingOrder.Account;
        }

        /// <summary>
        /// Quantity of the trade
        /// </summary>
        public int? Quantity
        {
            get => NewOrder.Quantity < ExistingOrder.Quantity ? NewOrder.Quantity : ExistingOrder.Quantity;
        }

        /// <summary>
        /// Price of the trade
        /// </summary>
        public decimal? Price
        {
            get => price ?? (price = ExistingOrder.Price);
        }

        /// <summary>
        /// Overall value of the trade.
        /// </summary>
        public decimal? Value
        {
            get => Quantity * Price;
        }

        /// <summary>
        /// The date and time the trade was created.
        /// </summary>
        public DateTime? TradeDate
        {
            get => tradeDate ?? throw new NullReferenceException("The TradeDate has not been set.");
            set => tradeDate = value;
        }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// The constructor of the Trade class.
        /// </summary>
        public Trade()
        { }

        /// <summary>
        /// The constructor of the Trade class.
        /// </summary>
        /// <param name="newOrder">The new order being placed.</param>
        /// <param name="existingOrder">The existing matching order to the new order.</param>
        public Trade(IOrder newOrder, IOrder existingOrder)
        {
            NewOrder = newOrder;
            ExistingOrder = existingOrder;
            TradeDate = DateTime.Now;
        }

        #endregion Constructor

    }
}