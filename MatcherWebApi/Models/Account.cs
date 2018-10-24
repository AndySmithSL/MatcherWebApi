using MatcherWebApi.Interfaces;
using System.Collections.Generic;

namespace MatcherWebApi.Models
{
    public class Account : IAccount
    {
        /// <summary>
        /// The Id of the Account
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// The account number as an 8-digit string, i.e. 00112345
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Name of the account holder.
        /// </summary>
        public string Name { get; set; }

        public ICollection<OrderBookItem> OrderBook { get; set; }
        public ICollection<OrderHistoryItem> OrderHistory { get; set; }
    }
}