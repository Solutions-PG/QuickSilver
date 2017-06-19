using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Core.Helpers
{
    public sealed class EqualityComparerHelper<T> : EqualityComparer<T>
    {
        #region " Variables "

        /// <summary>
        /// A delegate to determine whether two objects of type T are equal.
        /// </summary>
        Func<T, T, bool> _equalsFunc;

        /// <summary>
        /// A delegate to serve as a hash function for the specified object for hashing algorithms and data structures,
        /// such as a hash table.
        /// </summary>
        Func<T, int> _getHashCodeFunc;

        #endregion //Variables

        #region " Constructors "

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="equals">A delegate to determine whether two objects of type T are equal.</param>
        /// <param name="getHashCode">
        /// A delegate to serve as a hash function for the specified object for hashing algorithms and data structures,
        /// such as a hash table.
        /// </param>
        public EqualityComparerHelper(Func<T, T, bool> equals, Func<T, int> getHashCode) : base()
        {
            this._equalsFunc = equals;
            this._getHashCodeFunc = getHashCode;
        }

        #endregion //Constructors

        #region " Public methods "

        /// <summary>
        /// Determines whether two objects of type T are equal.
        /// </summary>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <returns>True if the specified objects are equal; Otherwise, false.</returns>
        public override bool Equals(T first, T second) => _equalsFunc?.Invoke(first, second) ?? false;

        /// <summary>
        /// Serves as a hash function for the specified object for hashing algorithms and data structures,
        /// such as a hash table.
        /// </summary>
        /// <param name="obj">The object for which to get a hash code.</param>
        /// <returns>A hash code for the specified object.</returns>
        public override int GetHashCode(T obj) => _getHashCodeFunc?.Invoke(obj) ?? 1;

        #endregion //Public methods
    }
}
