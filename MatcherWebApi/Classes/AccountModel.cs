using MatcherWebApi.Interfaces;
using MatcherWebApi.Models;
using System;

namespace MatcherWebApi.Classes
{
    public class AccountModel : Account, IAccountModel
    {
        #region Private Declarations

        private IAccountNumberGenerator generator = null;
        
        #endregion Private Declarations

        #region Public Properties

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
        /// Constructor of the AccountModel class.
        /// </summary>
        public AccountModel()
        { }

        /// <summary>
        /// Constructor of the AccountModel class.
        /// </summary>
        /// <param name="name">The name of the account number.</param>
        public AccountModel(string name)
            : this(null, name)
        { }

        /// <summary>
        /// Constructor of the AccountModel class.
        /// </summary>
        /// <param name="accountNumber">The account number of the account as an 8-digit string</param>
        /// <param name="name">The name of the account number.</param>
        public AccountModel(string accountNumber, string name)
        {
            if(String.IsNullOrEmpty(accountNumber))
            {
                accountNumber = Generator.Create();
            }

            AccountNumber = accountNumber;
            Name = name;
        }

        #endregion Constructors
    }
}