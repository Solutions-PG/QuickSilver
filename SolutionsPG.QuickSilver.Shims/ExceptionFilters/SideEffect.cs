using System;

namespace SolutionsPG.QuickSilver.Shims.ExceptionFilters
{
    public class SideEffect<TException> : ExceptionFilterBase<TException> where TException : Exception
    {
        private readonly Action<TException> _sideEffect;

        public SideEffect(Action<TException> sideEffect)
        {
            if (sideEffect == null)
                throw new ArgumentNullException(Cs60.nameof(() => sideEffect));
            _sideEffect = sideEffect;
        }

        protected override bool CanHandleImpl(TException typedException)
        {
            if (base.CanHandleImpl(typedException))
                _sideEffect(typedException);
            return false;
        }
    }
}
