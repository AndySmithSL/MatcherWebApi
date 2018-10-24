using MatcherWebApi.Interfaces;
using System;

namespace MatcherWebApi.Classes
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        #region Private Declarations

        private Random random = null;
        private int? minValue = null;
        private int? maxValue = null;
        private string startWith = null;

        #endregion Private Declarations

        #region Public Properties

        /// <summary>
        /// Random object for generating random accounbt numbers
        /// </summary>
        public Random Random
        {
            get => random ?? (random = new Random());
            set => random = value;
        }

        /// <summary>
        /// The lower bound of the number to be generated.
        /// </summary>
        public int? MinValue
        {
            get => minValue ?? (minValue = default(int));
            set => minValue = value;
        }

        /// <summary>
        /// The upper bound of the number to be generated.
        /// </summary>
        public int? MaxValue
        {
            get => maxValue ?? (maxValue = 999999);
            set => maxValue = value;
        }

        /// <summary>
        /// First static two digits of the account number.
        /// </summary>
        public string StartsWith
        {
            get => startWith ?? (startWith = "00");
            set => startWith = value;
        }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Constructor of the AccountNumberGenerator class.
        /// </summary>
        public AccountNumberGenerator()
        { }

        /// <summary>
        /// Constructor of the AccountNumberGenerator class.
        /// </summary>
        /// <param name="random">Object used to create random numbers.</param>
        public AccountNumberGenerator(Random random) :
            this(random, null, null, null)
        { }

        /// <summary>
        /// Constructor of the AccountNumberGenerator class.
        /// </summary>
        /// <param name="startsWith">First static two digits of the account number.</param>
        public AccountNumberGenerator(string startsWith) :
            this(null, null, startsWith)
        { }

        /// <summary>
        /// Constructor of the AccountNumberGenerator class.
        /// </summary>
        /// <param name="minValue">The lower bound of the number to be generated.</param>
        /// <param name="maxValue">The upper bound of the number to be generated.</param>
        public AccountNumberGenerator(int? minValue, int? maxValue)
            : this(minValue, maxValue, null)
        { }

        /// <summary>
        /// Constructor of the AccountNumberGenerator class.
        /// </summary>
        /// <param name="minValue">The lower bound of the number to be generated.</param>
        /// <param name="maxValue">The upper bound of the number to be generated.</param>
        /// <param name="startsWith">First static two digits of the account number.</param>
        public AccountNumberGenerator(int? minValue, int? maxValue, string startsWith)
            : this(null, minValue, maxValue, startsWith)
        { }

        /// <summary>
        /// Constructor of the AccountNumberGenerator class.
        /// </summary>
        /// <param name="random">Object used to create random numbers.</param>
        /// <param name="minValue">The lower bound of the number to be generated.</param>
        /// <param name="maxValue">The upper bound of the number to be generated.</param>
        /// <param name="startsWith">First static two digits of the account number.</param>
        public AccountNumberGenerator(Random random, int? minValue, int? maxValue, string startsWith)
        {
            Random = random;
            MinValue = minValue;
            MaxValue = maxValue;
            StartsWith = startsWith;
        }

        #endregion Constructors

        #region Methods

        public string Create()
        {
            return StartsWith + Random.Next(MinValue.Value, MaxValue.Value).ToString("D6");
        }

        #endregion Methods
    }
}