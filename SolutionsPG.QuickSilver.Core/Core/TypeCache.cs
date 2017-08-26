using System;

namespace SolutionsPG.QuickSilver.Core
{
    public static partial class TypeCache<T>
    {
        #region | Public properties |

        public static readonly Type Type = typeof(T);
        public static readonly bool IsValueType = Type.IsValueType;

        #endregion //Public properties
    }
}
