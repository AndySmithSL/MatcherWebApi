using MatcherWebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MatcherWebApi.Classes
{
    public class AccountManager : IAccountManager
    {
        #region Private Declarations

        private IList<IAccount> accounts = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// List of accounts.
        /// </summary>
        public IList<IAccount> Accounts
        {
            get => accounts ?? (accounts = new List<IAccount>());
            set => accounts = value;
        }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// Constructor of the AccountManager class.
        /// </summary>
        public AccountManager()
        { }

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
            IAccount account = new Account(accountNumber, name);
            Accounts.Add(account);

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