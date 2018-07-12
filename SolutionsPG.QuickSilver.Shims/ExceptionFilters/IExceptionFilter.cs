using System;

namespace SolutionsPG.QuickSilver.Shims.ExceptionFilters
{
    public interface IExceptionFilter
    {
        bool CanHandle(Exception exception);
        void Handle(Exception exception);
    }
}
