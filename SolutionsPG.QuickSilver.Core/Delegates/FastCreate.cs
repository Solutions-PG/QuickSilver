using System;
using System.Linq;
using System.Reflection;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Delegates
{
    public static partial class DelegateExtensions
    {
        public static bool TryGetMethod<T, TDelegate>(this T source, string methodName, out TDelegate method)
        {
            return source.TryGetMethod_(methodName, BindingFlags.Default, out method);
        }

        public static bool TryGetMethod<T, TDelegate>(this T source, string methodName, BindingFlags bindingFlags, out TDelegate method)
        {
            return source.TryGetMethod_(methodName, bindingFlags, out method);
        }

        private static bool TryGetMethod_<T, TDelegate>(this T source, string methodName, BindingFlags bindingFlags, out TDelegate method)
        {
            try
            {
                var delegateType = TypeCache<TDelegate>.Type;
                TypeCache<Delegate>.Type.IsAssignableFrom(delegateType).ThrowIfArgument(b => b == false, nameof(method));

                method = (TDelegate)(object)TypeCache<T>.Type.GetMethod(methodName, bindingFlags).CreateDelegate(delegateType, source);
                return true;
            }
            catch (Exception)
            {
                method = default(TDelegate);
                return false;
            }
        }
    }
}
