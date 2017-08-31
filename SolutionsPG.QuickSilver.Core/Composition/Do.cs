using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static IComposable Do(this IComposable obj, Action action)
        {
            return new ComposableDo(action, obj);
        }

        public static IComposable<T> Do<T>(this IComposable<T> obj, Action action)
        {
            return new ComposableDo<T>(action, obj);
        }

        #endregion //Public methods

        #region | Private methods |

        private class ComposableDo : IComposable
        {
            private readonly Action _action;
            private readonly IComposable _source;

            public ComposableDo(Action action, IComposable source)
            {
                _action = action;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                TDoResult DoAction()
                {
                    _action();
                    return action();
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction();
            }
        }

        private class ComposableDo<TSource> : IComposable<TSource>
        {
            private readonly Action _action;
            private readonly IComposable<TSource> _source;

            public ComposableDo(Action action, IComposable<TSource> source)
            {
                _action = action;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                TDoResult DoAction()
                {
                    _action();
                    return action();
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction();
            }

            public TDoResult Execute<TDoResult>(Func<TSource, TDoResult> action)
            {
                TDoResult DoAction(TSource source)
                {
                    _action();
                    return action(source);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource));
            }
        }

        #endregion //Private methods
    }
}
