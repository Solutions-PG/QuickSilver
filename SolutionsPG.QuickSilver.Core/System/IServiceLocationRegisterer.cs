using System;

namespace SolutionsPG.QuickSilver.Core.System
{
    public interface IServiceLocationRegisterer<out TCaller> where TCaller : IServiceLocationRegisterer<TCaller>
    {
        TCaller Register<T>();
        TCaller Register<T>(Func<T> resolver);
        TCaller Register<TBase, TConcrete>() where TConcrete : TBase;
        TCaller Register<TBase, TDerived>(Func<TDerived> resolver) where TDerived : TBase;
    }
}