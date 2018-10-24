namespace MatcherWebApi.Interfaces
{
    public interface IAccount
    {
        /// <summary>
        /// The Id of the Account
        /// </summary>
        int AccountId { get; set; }

        /// <summary>
        /// The account number as an 8-digit string, i.e. 00112345
        /// </summary>
        string AccountNumber { get; set; }

        /// <summary>
        /// Name of the account holder.
        /// </summary>
        string Name { get; set; }

    }
}