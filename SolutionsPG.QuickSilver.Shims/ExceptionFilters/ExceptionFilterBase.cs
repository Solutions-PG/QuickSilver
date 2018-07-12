using System;

namespace SolutionsPG.QuickSilver.Shims.ExceptionFilters
{
    public abstract class ExceptionFilterBase<TException> : IExceptionFilter where TException : Exception
    {
        public bool CanHandle(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(Cs60.nameof(() => exception));

            var typedException =  exception as TException;
            return (typedException != null) && CanHandleImpl(typedException);
        }

        protected virtual bool CanHandleImpl(TException exception)
        {
            return true;
        }

        public void Handle(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(Cs60.nameof(() => exception));

            var typedException = exception as TException;

            if (typedException == null)
                throw new ArgumentException("Can't handle that exception type : " + typeof(TException), Cs60.nameof(() => exception));

            this.HandleImpl(typedException);
        }

        public virtual void HandleImpl(TException exception)
        {

        }
    }
}
