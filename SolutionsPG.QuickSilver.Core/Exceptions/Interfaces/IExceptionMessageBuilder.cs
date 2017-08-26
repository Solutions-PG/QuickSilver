using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces
{
    public interface IExceptionMessageBuilder
    {
        IExceptionMessageBuilder AddSummary(string summary);

        IExceptionMessageBuilder AddParameter<T>(string parameterName, T parameter);

        IExceptionMessageBuilder AddMoreInfo(string title, string info);

        IExceptionMessageBuilder AddMoreInfo(string title, IEnumerable<string> infos);

        IExceptionMessageBuilder AddMoreInfo<T>(string title, IEnumerable<T> infos, Func<T, string> infoToString);

        IExceptionMessageBuilder AddExceptionSource<T>(T source);

        string Build();
    }
}