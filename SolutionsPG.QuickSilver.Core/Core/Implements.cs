using System;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core
{
    public static partial class TypeExtensions
    {
        public static bool Implements<TAncestor>(this Type type) => type.Implements_(TypeCache<TAncestor>.Type);

        public static bool Implements(this Type type, Type ancestor)
        {
            ancestor.ThrowIfArgumentNull(nameof(ancestor));
            return type.Implements_(ancestor);
        }

        private static bool Implements_(this Type type, Type ancestor)
        {
            return ancestor.IsAssignableFrom(type);
        }
    }
}
