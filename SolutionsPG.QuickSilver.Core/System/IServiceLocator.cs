using System;

namespace SolutionsPG.QuickSilver.Core.System
{
    public interface IServiceLocator : IServiceLocationResolver, IServiceLocationRegisterer<IServiceLocator>
    {
    }
}