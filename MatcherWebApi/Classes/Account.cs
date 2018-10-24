using MatcherWebApi.Interfaces;
using System;

namespace MatcherWebApi.Classes
{
    public class Account : IAccount
    {
        #region Private Declarations

        private IAccountNumberGenerator generator = null;
        private string accountNumber = null;
        private string name = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// The account number as an 8-digit string, i.e. 00112345
        /// </summary>
        public string AccountNumber
        {
            get => accountNumber ?? (accountNumber = Generator.Create());
            set => accountNumber = value;
        }

        /// <summary>
        /// Name of the account holder.
        /// </summary>
        public string Name
        {
            get => name ?? throw new NullReferenceException("The name of the account has not been set.");
            set => name = value;
        }

        /// <summary>
        /// Account number generator
        /// </summary>
        public IAccountNumberGenerator Generator
        {
            get => generator ?? (generator = new AccountNumberGenerator());
            set => generator = value;
        }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Constructor of the Account class.
        /// </summary>
        public Account()
        { }

        /// <summary>
        /// Constructor of the Account class.
        /// </summary>
        /// <param name="name">The name of the account number.</param>
        public Account(string name)
            : this(null, name)
        { }

        /// <summary>
        /// Constructor of the Account class.
        /// </summary>
        /// <param name="accountNumber">The account number of the account as an 8-digit string</param>
        /// <param name="name">The name of the account number.</param>
        public Account(string accountNumber, string name)
        {
            AccountNumber = accountNumber;
            Name = name;
        }

        #endregion Constructors
    }
}