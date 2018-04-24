using System;

namespace SolutionsPG.QuickSilver.Core.System
{
    public interface IServiceLocator<out T> : IServiceLocationResolver, IServiceLocationRegisterer<T> where T: IServiceLocator<T>
    {
    }
}