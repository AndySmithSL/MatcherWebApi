using MatcherWebApi.Enumerators;
using System.Collections.Generic;

namespace MatcherWebApi.Interfaces
{
    public interface IOrderGroup
    {
        /// <summary>
        /// List of orders making up the group of orders.
        /// </summary>
        IList<IOrder> Orders { get; set; }

        /// <summary>
        /// The quantity of the orders
        /// </summary>
        int? Quantity { get; }

        /// <summary>
        /// The value of all the orders.
        /// </summary>
        decimal? Value { get; }

        /// <summary>
        /// The price of the orders
        /// </summary>
        decimal? Price { get; set; }

        /// <summary>
        /// Are the orders buy or sell
        /// </summary>
        OrderType? OrderType { get; set; }

        /// <summary>
        /// Add an order to the Order Group class.
        /// </summary>
        /// <param name="order">The order to Add.</param>
        void Add(IOrder order);

        /// <summary>
        /// Add a list of orders to the Order Group class.
        /// </summary>
        /// <param name="orders">The list of orders to add.</param>
        void Add(IList<IOrder> orders);

    }
}