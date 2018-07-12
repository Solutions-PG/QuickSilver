using System;

namespace SolutionsPG.QuickSilver.Shims.ExceptionFilters
{
    public static class ExceptionFilter
    {
        static ExceptionFilter() { }

        public static IExceptionFilter Ignore<TException>() where TException : Exception
        {
            return ExceptionFilters.Ignore<TException>.Instance;
        }

        public static IExceptionFilter[] AbsorbAllExceptions { get { return AbsorbAllExceptionsField; } }
        private static readonly IExceptionFilter[] AbsorbAllExceptionsField = { ExceptionFilter.Ignore<Exception>() };

        public static IExceptionFilter[] ExceptionsPassthrough { get { return ExceptionsPassthroughField; } }
        private static readonly IExceptionFilter[] ExceptionsPassthroughField = { };
    }
}
