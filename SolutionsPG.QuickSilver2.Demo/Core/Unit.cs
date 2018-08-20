using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace SolutionsPG.QuickSilver2.Demo.Core
{
    /// <summary>Provides static methods for creating units. </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct Unit : IEquatable<Unit>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<Unit>
    {
        /// <summary>Returns a value that indicates whether the current <see cref="T:Unit" /> instance is equal to a specified object.  </summary>
        /// <param name="obj">The object to compare to the current instance. </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> is a <see cref="T:Unit" /> instance; otherwise, <see langword="false" />. </returns>
        public override bool Equals(object obj) => obj is Unit;

        /// <summary>Determines whether two <see cref="T:Unit" /> instances are equal. This method always returns <see langword="true" />. </summary>
        /// <param name="other">The unit to compare with the current instance.</param>
        /// <returns>This method always returns <see langword="true" />. </returns>
        public bool Equals(Unit other) => true;

        /// <inheritdoc />
        /// <summary>Determines whether an object is structurally equal to the current instance.</summary>
        /// <param name="other">The object to compare with the current instance.</param>
        /// <param name="comparer">An object that determines whether the current instance and <paramref name="other" /> are equal. </param>
        /// <returns>
        /// <see langword="true" /> if the two objects are equal; otherwise, <see langword="false" />.</returns>
        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer) => other is Unit;

        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <param name="obj">An object to compare with this instance. </param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order. </returns>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="obj" /> is not the same type as this instance. </exception>
        int IComparable.CompareTo(object other)
        {
            if (other == null)
                return 1;
            if (!(other is Unit))
                throw new ArgumentException($"Incorrect type : {this.GetType()}", nameof(other));
            return 0;
        }

        /// <summary>Compares the current <see cref="T:Unit" /> instance with a specified object.</summary>
        /// <param name="other">The object to compare with the current instance. </param>
        /// <returns>Returns 0 if <paramref name=" other" /> is a <see cref="T:Unit" /> instance and 1 if <paramref name="other" /> is <see langword="null" />.   </returns>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="other" /> is not a <see cref="T:Unit" /> instance. </exception>
        public int CompareTo(Unit other) => 0;

        /// <summary>Determines whether the current collection object precedes, occurs in the same position as, or follows another object in the sort order.</summary>
        /// <param name="other">The object to compare with the current instance.</param>
        /// <param name="comparer">An object that compares members of the current collection object with the corresponding members of <paramref name="other" />.</param>
        /// <returns>An integer that indicates the relationship of the current collection object to <paramref name="other" />, as shown in the following table.Return valueDescription-1The current instance precedes <paramref name="other" />.0The current instance and <paramref name="other" /> are equal.1The current instance follows <paramref name="other" />.</returns>
        /// <exception cref="T:System.ArgumentException">This instance and <paramref name="other" /> are not the same type.</exception>
        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;
            if (!(other is Unit))
                throw new ArgumentException($"Incorrect type : {this.GetType()}", nameof(other));
            return 0;
        }

        /// <summary>Returns the hash code for the current <see cref="T:Unit" /> instance. </summary>
        /// <returns>The hash code for the current <see cref="T:Unit" /> instance. </returns>
        public override int GetHashCode() => 0;

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => 0;

        /// <summary>Returns the string representation of this <see cref="T:Unit" /> instance.</summary>
        /// <returns>This method always returns "()".</returns>
        public override string ToString() => "()";

        /// <summary>Creates a new unit.</summary>
        /// <returns>A new unit. </returns>
        public static Unit Create() => new Unit();
    }

}