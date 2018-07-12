using System;

namespace SolutionsPG.QuickSilver.Core
{
    public static partial class TypeCache<T>
    {
        #region | Properties |

        public static Type Type { get; } = typeof(T);
        public static bool IsValueType => Type.IsValueType;
        public static bool IsConcrete => Type.IsConcrete();

        #endregion //Properties
    }
}
