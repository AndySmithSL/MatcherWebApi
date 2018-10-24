using System;

namespace MatcherWebApi.Interfaces
{
    public interface IAccountNumberGenerator
    {
        /// <summary>
        /// Random object for generating random accounbt numbers
        /// </summary>
        Random Random { get; set; }

        /// <summary>
        /// The lower bound of the number to be generated.
        /// </summary>
        int? MinValue { get; set; }

        /// <summary>
        /// The upper bound of the number to be generated.
        /// </summary>
        int? MaxValue { get; set; }

        /// <summary>
        /// First static two digits of the account number.
        /// </summary>
        string StartsWith { get; set; }

        /// <summary>
        /// Create a new account number.
        /// </summary>
        /// <returns>An account number</returns>
        string Create();
    }
}