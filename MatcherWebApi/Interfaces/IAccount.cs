namespace MatcherWebApi.Interfaces
{
    public interface IAccount
    {
        /// <summary>
        /// The account number as an 8-digit string, i.e. 00112345
        /// </summary>
        string AccountNumber { get; set; }

        /// <summary>
        /// Name of the account holder.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Account number generator
        /// </summary>
        IAccountNumberGenerator Generator { get; set; }

    }
}