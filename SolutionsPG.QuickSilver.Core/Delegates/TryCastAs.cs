using System;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Delegates
{
    public static partial class DelegateExtensions
    {
        public static bool TryCastAs<TDelegate>(this MulticastDelegate source, out TDelegate destination)
        {
            try
            {
                var delegateType = TypeCache<TDelegate>.Type;
                TypeCache<Delegate>.Type.IsAssignableFrom(delegateType).ThrowIfArgument(b => b == false, nameof(destination));

                Delegate result = null;
                foreach (var sourceItem in source.GetInvocationList())
                {
                    var copy = Delegate.CreateDelegate(delegateType, sourceItem.Target, sourceItem.Method);
                    result = Delegate.Combine(result, copy);
                }

                destination =(TDelegate)(object)result;
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
