using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using SolutionsPG.QuickSilver.Shims.ExceptionFilters;

namespace SolutionsPG.QuickSilver.Shims
{
    public static partial class Cs60
    {
        public static void @try(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(Cs60.nameof(() => action));
            Cs60.TryImpl(action, null, ExceptionFilter.AbsorbAllExceptions);
        }

        public static void @try(Action action, Action @finally)
        {
            if (action == null)
                throw new ArgumentNullException(Cs60.nameof(() => action));
            Cs60.TryImpl(action, @finally, ExceptionFilter.ExceptionsPassthrough);
        }

        public static void @try(Action action, params IExceptionFilter[] exceptionFilters)
        {
            if (action == null)
                throw new ArgumentNullException(Cs60.nameof(() => action));
            if (exceptionFilters == null)
                throw new ArgumentNullException(Cs60.nameof(() => exceptionFilters));
            Cs60.TryImpl(action, null, exceptionFilters);
        }

        public static void @try(Action action, Action @finally, params IExceptionFilter[] exceptionFilters)
        {
            if (action == null)
                throw new ArgumentNullException(Cs60.nameof(() => action));
            if (exceptionFilters == null)
                throw new ArgumentNullException(Cs60.nameof(() => exceptionFilters));
            Cs60.TryImpl(action, @finally, exceptionFilters);
        }

        private static void TryImpl(Action action, Action @finally, params IExceptionFilter[] exceptionFilters)
        {
            TryGetImpl(() => { action(); return default(object); }, @finally, exceptionFilters);
        }

        public static T tryGet<T>(Func<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(Cs60.nameof(() => action));
            return Cs60.TryGetImpl(action, null, ExceptionFilter.AbsorbAllExceptions);
        }

        public static T tryGet<T>(Func<T> action, Action @finally)
        {
            if (action == null)
                throw new ArgumentNullException(Cs60.nameof(() => action));
            return Cs60.TryGetImpl(action, @finally, ExceptionFilter.ExceptionsPassthrough);
        }

        public static T tryGet<T>(Func<T> action, params IExceptionFilter[] exceptionFilters)
        {
            if (action == null)
                throw new ArgumentNullException(Cs60.nameof(() => action));
            if (exceptionFilters == null)
                throw new ArgumentNullException(Cs60.nameof(() => exceptionFilters));
            return Cs60.TryGetImpl(action, null, exceptionFilters);
        }

        public static T tryGet<T>(Func<T> action, Action @finally, params IExceptionFilter[] exceptionFilters)
        {
            if (action == null)
                throw new ArgumentNullException(Cs60.nameof(() => action));
            if (exceptionFilters == null)
                throw new ArgumentNullException(Cs60.nameof(() => exceptionFilters));
            return Cs60.TryGetImpl(action, @finally, exceptionFilters);
        }

        private static T TryGetImpl<T>(Func<T> action, Action @finally, params IExceptionFilter[] exceptionFilters)
        {
            T result = default(T);

            try
            {
                result = action();
            }
            catch (Exception e)
            {
                var exceptionHandler = new ExceptionHandler(e, exceptionFilters);
                if (exceptionHandler.Handled() == false)
                    exceptionHandler.Rethrow();
            }
            finally
            {
                if (@finally != null)
                {
                    @finally();
                }
            }

            return result;
        }

        private static T TryGetImpl<T>(Func<T> action, Action @finally, IExceptionFilter exceptionFilter)
        {
            return TryGetImpl(action, @finally, e => new ExceptionHandlerSingle(e, exceptionFilter));
        }

        private static T TryGetImpl<T>(Func<T> action, Action @finally, IExceptionFilter exceptionFilter1, IExceptionFilter exceptionFilter2)
        {
            return TryGetImpl(action, @finally, e => new ExceptionHandlerMultiple(e, exceptionFilter1, exceptionFilter2));
        }

        private static T TryGetImpl<T, TExceptionHandler>(Func<T> action, Action @finally, Func<Exception, TExceptionHandler> factory) where TExceptionHandler : IExceptionHandler
        {
            return TryGetImpl(action, @finally, e =>
            {
                var exceptionHandler = factory(e);
                if (exceptionHandler.Handled() == false)
                    exceptionHandler.Rethrow();
            });
        }

        private static T TryGetImpl<T>(Func<T> action, Action @finally, Action<Exception> handler)
        {
            var result = default(T);

            try
            {
                result = action();
            }
            catch (Exception e)
            {
                handler(e);
            }
            finally
            {
                if (@finally != null)
                {
                    @finally();
                }
            }

            return result;
        }

        private interface IExceptionHandler
        {
            bool Handled();
            void Rethrow();
        }

        private struct ExceptionHandlerBase
        {
            private readonly Exception _e;

            public ExceptionHandlerBase(Exception e)
            {
                _e = e;
            }

            public void Handle(IExceptionFilter handler)
            {
                handler.Handle(_e);
            }

            public bool CanHandle(IExceptionFilter handler)
            {
                try { return handler.CanHandle(_e); }
                catch { return false; }
            }

            public void Rethrow()
            {
                ExceptionDispatchInfo.Capture(_e).Throw();
            }
        }

        private struct ExceptionHandlerSingle : IExceptionHandler
        {
            private readonly ExceptionHandlerBase _base;
            private readonly IExceptionFilter _exceptionFilter;

            public ExceptionHandlerSingle(Exception e, IExceptionFilter exceptionFilter)
            {
                _base = new ExceptionHandlerBase(e);
                _exceptionFilter = exceptionFilter;
            }

            public bool Handled()
            {
                if (_base.CanHandle(_exceptionFilter))
                {
                    _base.Handle(_exceptionFilter);
                    return true;
                }
                return false;
            }

            public void Rethrow()
            {
                _base.Rethrow();
            }
        }

        private struct ExceptionHandlerMultiple : IExceptionHandler
        {
            private readonly ExceptionHandlerBase _base;
            private readonly IEnumerable<IExceptionFilter> _exceptionFilters;

            public ExceptionHandlerMultiple(Exception e, params IExceptionFilter[] exceptionFilters)
            {
                _base = new ExceptionHandlerBase(e);
                _exceptionFilters = exceptionFilters;
            }

            public bool Handled()
            {
                IExceptionFilter handler;
                if (TryGetFirst(out handler))
                {
                    _base.Handle(handler);
                    return true;
                }
                return false;
            }

            private bool TryGetFirst(out IExceptionFilter handler)
            {
                using (var enumerator = _exceptionFilters.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (_base.CanHandle(enumerator.Current))
                        {
                            handler = enumerator.Current;
                            return true;
                        }
                    }
                }

                handler = default(IExceptionFilter);
                return false;
            }

            public void Rethrow()
            {
                _base.Rethrow();
            }
        }

        private struct ExceptionHandler : IExceptionHandler
        {
            private readonly Exception _e;
            private readonly IEnumerable<IExceptionFilter> _exceptionFilters;

            public ExceptionHandler(Exception e, IEnumerable<IExceptionFilter> exceptionFilters)
            {
                _e = e;
                _exceptionFilters = exceptionFilters;
            }

            public bool Handled()
            {
                IExceptionFilter handler;
                if (TryGetFirst(out handler))
                {
                    Handle(handler);
                    return true;
                }
                return false;
            }

            private void Handle(IExceptionFilter handler)
            {
                handler.Handle(_e);
            }

            private bool TryGetFirst(out IExceptionFilter handler)
            {
                using (var enumerator = _exceptionFilters.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (CanHandle(enumerator.Current))
                        {
                            handler = enumerator.Current;
                            return true;
                        }
                    }
                }

                handler = default(IExceptionFilter);
                return false;
            }

            private bool CanHandle(IExceptionFilter handler)
            {
                try { return handler.CanHandle(_e); }
                catch { return false; }
            }

            public void Rethrow()
            {
                ExceptionDispatchInfo.Capture(_e).Throw();
            }
        }
    }

    public static class Exemples
    {
        public static void Try()
        {
            Cs60.@try(() =>
            {
                /*Try*/
            }, () =>
            {
                /*finally*/
            }, new Filter<Exception>(e =>
            {
                return false;
            }, e =>
            {

            }));
        }
    }
}
