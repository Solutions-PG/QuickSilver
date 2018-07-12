using System;

namespace SolutionsPG.QuickSilver.Shims.ExceptionFilters
{
    public class Filter<TException> : Catch<TException> where TException : Exception
    {
        private readonly Func<TException, bool> _canHandle;

        public Filter(Func<TException, bool> canHandle, Action<TException> handler) : base(handler)
        {
            _canHandle = canHandle;
        }

        protected override bool CanHandleImpl(TException exception)
        {
            bool canHandle = false;
            if (base.CanHandleImpl(exception))
                canHandle = _canHandle(exception);
            return canHandle;
        }
    }
}
