using System;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.System
{
    public static class ServiceLocator
    {
        private static volatile Func<IServiceLocator> _provider;

        public static IServiceLocator Instance => _provider.ThrowIfNull(_ => new InvalidOperationException("Provider not set"))();

        public static bool IsProviderDefined => _provider != null;

        public static void SetProvider(Func<IServiceLocator> provider) => _provider = provider;
    }
}
