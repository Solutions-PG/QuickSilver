using System;

namespace SolutionsPG.QuickSilver.Shims.ExceptionFilters
{
    internal class Ignore<TException> : ExceptionFilterBase<TException> where TException : Exception
    {
        private static readonly IExceptionFilter IgnoreField = new Ignore<TException>();
        public static IExceptionFilter Instance { get { return IgnoreField; } }
        static Ignore() { }

    }
}
