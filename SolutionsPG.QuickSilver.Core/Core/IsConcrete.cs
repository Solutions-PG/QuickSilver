using System;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core
{
    public static partial class TypeExtensions
    {
        public static bool IsConcrete(this Type type)
        {
            type.ThrowIfArgumentNull(nameof(type));
            return (type.IsInterface || type.IsAbstract) == false;
        }
    }
}
