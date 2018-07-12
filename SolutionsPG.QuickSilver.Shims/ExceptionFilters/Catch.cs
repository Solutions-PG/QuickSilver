using System;

namespace SolutionsPG.QuickSilver.Shims.ExceptionFilters
{
    public class Catch<TException> : ExceptionFilterBase<TException> where TException : Exception
    {
        private readonly Action<TException> _handler;

        public Catch(Action<TException> handler)
        {
            if (handler == null)
                throw new ArgumentNullException(Cs60.nameof(() => handler));
            _handler = handler;
        }

        public override void HandleImpl(TException typedException)
        {
            base.HandleImpl(typedException);
            _handler(typedException);
        }
    }
}
