using MatcherWebApi.Enumerators;
using MatcherWebApi.Interfaces;
using System;

namespace MatcherWebApi.Classes
{
    public class Order : IOrder
    {
        #region Private Declarations

        private IAccount account = null;
        private int? quantity = null;
        private decimal? price = null;
        private OrderType? orderType = null;
        private DateTime? orderDate = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// The account of the order
        /// </summary>
        public IAccount Account
        {
            get => account ?? throw new NullReferenceException("The account has not been set.");
            set => account = value;
        }

        /// <summary>
        /// The quantity of the order
        /// </summary>
        public int? Quantity
        {
            get => quantity ?? (quantity = default(int));
            set => quantity = value;
        }

        /// <summary>
        /// The price of the order
        /// </summary>
        public decimal? Price
        {
            get => price ?? (price = default(decimal));
            set => price = value;
        }

        /// <summary>
        /// The value of the order
        /// </summary>
        public decimal? Value
        {
            get => Quantity * Price;
        }

        /// <summary>
        /// Is the order a buy or sell
        /// </summary>
        public OrderType? OrderType
        {
            get => orderType ?? throw new NullReferenceException("The ordertype has not been set.");
            set => orderType = value;
        }

        /// <summary>
        /// The date and time of the order
        /// </summary>
        public DateTime? OrderDate
        {
            get => orderDate ?? (orderDate = DateTime.Now);
            set => orderDate = value;
        }

        /// <summary>
        /// Clone the order
        /// </summary>
        /// <returns>Return a copy of the order.</returns>
        public IOrder Clone
        {
            get => (IOrder)this.MemberwiseClone();
        }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// The constructor of the Order class.
        /// </summary>
        public Order()
        { }

        /// <summary>
        /// The constructor of the Order class.
        /// </summary>
        /// <param name="account">The account of the order</param>
        public Order(IAccount account)
            : this(account, null, null, null)
        { }

        /// <summary>
        /// The constructor of the Order class.
        /// </summary>
        /// <param name="account">The account of the order</param>
        /// <param name="quantity">The quantity of the order</param>
        /// <param name="price">The price of the order</param>
        /// <param name="orderType">Is the order a buy or a sell.</param>
        public Order(IAccount account, int? quantity, decimal? price, OrderType? orderType)
        {
            Account = account;
            Quantity = quantity;
            Price = price;
            OrderType = orderType;
        }

        #endregion Constructor

    }
}