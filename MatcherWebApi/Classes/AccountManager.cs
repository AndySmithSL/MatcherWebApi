using MatcherWebApi.Interfaces;
using MatcherWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatcherWebApi.Classes
{
    public class AccountManager : IAccountManager
    {
        #region Private Declarations

        private MatcherContext context = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// List of accounts.
        /// </summary>
        public IEnumerable<IAccount> Accounts
        {
            get => Context.Accounts.ToList();
        }

        /// <summary>
        /// Database context to retrieve the Accounts from.
        /// </summary>
        public MatcherContext Context
        {
            get => context ?? throw new NullReferenceException("The database context has not been set.");
            set => context = value;
        }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// Constructor of the AccountManager class.
        /// </summary>
        public AccountManager()
        { }

        /// <summary>
        /// Constructor of the AccountManager class.
        /// </summary>
        /// <param name="context">The context to load the data from.</param>
        public AccountManager(MatcherContext context)
        {
            Context = context;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="name">The name to use in the account.</param>
        /// <returns>The new account.</returns>
        public IAccount CreateAccount(string name)
        {
            return CreateAccount(null, name);
        }

        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="accountNumber">The account number to use in the account.</param>
        /// <param name="name">The name to use in the account.</param>
        /// <returns></returns>
        public IAccount CreateAccount(string accountNumber, string name)
        {
            var account = new AccountModel(accountNumber, name);

            Context.Accounts.Add(account);
            Context.SaveChanges();

            return account;
        }

        /// <summary>
        /// Find the account by the account number.
        /// </summary>
        /// <param name="accountNumber">The account number of the account to search for.</param>
        /// <returns>The account if found otherwise null.</returns>
        public IAccount FindAccountByAccountNumber(string accountNumber)
        {
            return Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Find the account by the name of the holder.
        /// </summary>
        /// <param name="accountNumber">The name of the holder to search for.</param>
        /// <returns>The account if found otherwise null.</returns>
        public IAccount FindAccountByName(string name)
        {
            return Accounts.FirstOrDefault(a => a.Name == name);
        }

        #endregion Methods

    }
}