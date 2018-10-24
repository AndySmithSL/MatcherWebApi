using MatcherWebApi.Enumerators;
using MatcherWebApi.Interfaces;
using System;

namespace MatcherWebApi.Classes
{
    public class AggregateOrder : OrderGroup
    {
        #region Constructor

        /// <summary>
        /// The constructor of the AggregateOrder class.
        /// </summary>
        public AggregateOrder()
        { }

        /// <summary>
        /// The constructor of the AggregateOrder class.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="orderType"></param>
        public AggregateOrder(decimal price, OrderType orderType)
            : base(price, orderType)
        { }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Add an order to the Aggregate Order object.
        /// </summary>
        /// <param name="order">The order to Add.</param>
        public override void Add(IOrder order)
        {
            if (order.Price != Price || order.OrderType != OrderType)
            {
                throw new ApplicationException("The Price or OrderType is different.");
            }
            Orders.Add(order);
        }

        #endregion Methods

    }
}