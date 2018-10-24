using MatcherWebApi.Models;
using System.Collections.Generic;

namespace MatcherWebApi.Interfaces
{
    public interface IAccountManager
    {
        /// <summary>
        /// List of accounts.
        /// </summary>
        IEnumerable<IAccount> Accounts { get; }

        /// <summary>
        /// Database context to retrieve the Accounts from.
        /// </summary>
        MatcherContext Context { get; set; }

        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="name">The name to use in the account.</param>
        /// <returns>The new account.</returns>
        IAccount CreateAccount(string name);

        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="accountNumber">The account number to use in the account.</param>
        /// <param name="name">The name to use in the account.</param>
        /// <returns></returns>
        IAccount CreateAccount(string accountNumber, string name);

        /// <summary>
        /// Find the account by the account number.
        /// </summary>
        /// <param name="accountNumber">The account number of the account to search for.</param>
        /// <returns>The account if found otherwise null.</returns>
        IAccount FindAccountByAccountNumber(string accountNumber);

        /// <summary>
        /// Find the account by the name of the holder.
        /// </summary>
        /// <param name="accountNumber">The name of the holder to search for.</param>
        /// <returns>The account if found otherwise null.</returns>
        IAccount FindAccountByName(string name);

    }
}