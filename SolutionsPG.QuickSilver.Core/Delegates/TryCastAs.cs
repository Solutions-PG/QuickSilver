using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Delegates
{
    public static partial class DelegateExtensions
    {
        private static Func<Type, Delegate, Delegate> CreateDelegate { get; } = (delegateType, sourceItem) => Delegate.CreateDelegate(delegateType, sourceItem.Target, sourceItem.Method);

        public static bool TryCastAs<TDelegate>(this Delegate source, out TDelegate destination)
        {
            try
            {
                var delegateType = TypeCache<TDelegate>.Type;
                TypeCache<Delegate>.Type.IsAssignableFrom(delegateType).ThrowIfArgument(CommonClosure.Equals(false), nameof(destination));

                var delegates = source.GetInvocationList()
                    .Select(CommonClosure.Apply(CreateDelegate, delegateType))
                    .ToArray();
                destination = (TDelegate)(object)Delegate.Combine(delegates);

                return true;
            }
            catch(Exception)
            {
                destination = default(TDelegate);
                return false;
            }
        }
    }
}
