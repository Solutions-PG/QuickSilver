using System;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.System.ServiceLocation
{
    public abstract class ConfigurationBase : IConfiguration
    {
        public bool Ignore { get; }
        public bool Configured { get; private set; }

        protected ConfigurationBase() : this(false) { }

        protected ConfigurationBase(bool ignore)
        {
            Ignore = ignore;
            Configured = false;
        }

        public void Configure(IServiceLocator container)
        {
            if (Ignore || Configured) return;

            container.ThrowIfArgumentNull(nameof(container));

            ConfigureImpl(container);

            Configured = true;
        }

        protected abstract void ConfigureImpl(IServiceLocator container);
    }
}