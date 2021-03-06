﻿using System.Text;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Strings
{
    public static partial class StringExtensions
    {
        #region " Public methods "

        public static StringBuilder AsMutable(this string str) => new StringBuilder(str.ThrowIfArgumentNull(nameof(str)));

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods
    }
}
