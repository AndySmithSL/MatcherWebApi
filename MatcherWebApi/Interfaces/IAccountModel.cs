namespace MatcherWebApi.Interfaces
{
    public interface IAccountModel : IAccount
    {
        /// <summary>
        /// Account number generator
        /// </summary>
        IAccountNumberGenerator Generator { get; set; }
    }
}