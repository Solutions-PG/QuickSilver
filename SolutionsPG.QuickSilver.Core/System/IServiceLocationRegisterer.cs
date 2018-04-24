using System;
using SolutionsPG.QuickSilver.Core.System.ServiceLocation;

namespace SolutionsPG.QuickSilver.Core.System
{
    public interface IServiceLocationRegisterer<out TCaller> where TCaller : IServiceLocationRegisterer<TCaller>
    {
        TCaller Register<TBase, TConcrete>() where TConcrete : TBase;
        TCaller Register<TBase, TDerived>(Func<TDerived> resolver) where TDerived : TBase;
        TCaller Configure<TConfig>() where TConfig : ConfigurationBase, new();
    }
}