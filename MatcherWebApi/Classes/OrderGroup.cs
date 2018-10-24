using MatcherWebApi.Enumerators;
using MatcherWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatcherWebApi.Classes
{
    public class OrderGroup : IOrderGroup
    {
        #region Private Declarations

        private IList<IOrder> orders = null;
        private decimal? price = null;
        private OrderType? orderType = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// List of orders making up the group of orders.
        /// </summary>
        public IList<IOrder> Orders
        {
            get => orders ?? (orders = new List<IOrder>());
            set => orders = value;
        }

        /// <summary>
        /// The quantity of the orders
        /// </summary>
        public int? Quantity => orders.Sum(order => order.Quantity);

        /// <summary>
        /// The value of all the orders.
        /// </summary>
        public decimal? Value => orders.Sum(order => order.Value);

        /// <summary>
        /// The price of the orders
        /// </summary>
        public decimal? Price
        {
            get => price ?? throw new NullReferenceException("The price has not been set.");
            set => price = value;
        }

        /// <summary>
        /// Are the orders buy or sell
        /// </summary>
        public OrderType? OrderType
        {
            get => orderType ?? throw new NullReferenceException("The order type has not been set.");
            set => orderType = value;
        }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// The constructor of the OrderGroup class.
        /// </summary>
        public OrderGroup()
        { }

        /// <summary>
        /// The constructor of the OrderGroup class.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="orderType"></param>
        public OrderGroup(decimal price, OrderType orderType)
        {
            Price = price;
            OrderType = orderType;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Add an order to the Order Group class.
        /// </summary>
        /// <param name="order">The order to Add.</param>
        public virtual void Add(IOrder order)
        {
            Orders.Add(order);
        }

        /// <summary>
        /// Add a list of orders to the Order Group class.
        /// </summary>
        /// <param name="orders">The list of orders to add.</param>
        public virtual void Add(IList<IOrder> orders)
        {
            foreach (var order in orders)
            {
                Add(order);
            }
        }

        #endregion Methods

    }
}