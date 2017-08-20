using System;
using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
{
    public sealed class ComparerHelper<T> : Comparer<T>
    {
        #region " Variables "

        /// <summary>
        /// A delegate to perform a comparison of two objects of the same type and returns a value indicating whether
        /// one object is less than, equal to, or greater than the other.
        /// </summary>
        private readonly Comparison<T> _compareFunc;

        #endregion //Variables

        #region " Constructors "

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="compare">
        /// A delegate to perform a comparison of two objects of the same type and returns a value indicating whether
        /// one object is less than, equal to, or greater than the other.
        /// </param>
        public ComparerHelper(Comparison<T> compare) : base()
        {
            _compareFunc = compare;
        }

        #endregion //Constructors

        #region " Public methods "

        /// <summary>
        /// Performs a comparison of two objects of the same type and returns a value indicating whether one object is
        /// less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <returns></returns>
        public override int Compare(T first, T second) => _compareFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke(first, second);

        /// <summary>
        /// Act as a convenient converter when a function need a Comparer{T} and doesn't offer the possibility to
        /// directly use a Comparison{T}.
        /// </summary>
        /// <param name="compare"></param>
        public static implicit operator ComparerHelper<T>(Comparison<T> compare) => new ComparerHelper<T>(compare);

        #endregion //Public methods
    }
}
