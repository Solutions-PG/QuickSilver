using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces
{
    public interface IExceptionMessageBuilderFacade
    {
        IExceptionMessageBuilderFacade AddSummary(string summary);

        IExceptionMessageBuilderFacade AddParameter<T>(string parameterName, T parameter);

        IExceptionMessageBuilderFacade AddMoreInfo(string title, string info);

        IExceptionMessageBuilderFacade AddMoreInfo(string title, IEnumerable<string> infos);

        IExceptionMessageBuilderFacade AddMoreInfo<T>(string title, IEnumerable<T> infos, Func<T, string> infoToString);
    }
}