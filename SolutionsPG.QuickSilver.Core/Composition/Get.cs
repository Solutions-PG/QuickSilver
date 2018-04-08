using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static IComposable<TResult> Get<TResult>(this IComposable obj, Func<TResult> action)
        {
            return new ComposableGet<TResult>(action, obj);
        }

        public static IComposable<TSource, TResult> Get<TSource, TResult>(this IComposable<TSource> obj, Func<TResult> action)
        {
            return new ComposableGet<TSource, TResult>(action, obj);
        }

        public static IComposable<TSource1, TSource2, TResult> Get<TSource1, TSource2, TResult>(this IComposable<TSource1, TSource2> obj, Func<TResult> action)
        {
            return new ComposableGet<TSource1, TSource2, TResult>(action, obj);
        }

        #endregion //Public methods

        #region | Private methods |

        private class ComposableGet<T> : IComposable<T>
        {
            private readonly Func<T> _action;
            private readonly IComposable _source;

            public ComposableGet(Func<T> action, IComposable source)
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

            public TDoResult Execute<TDoResult>(Func<T, TDoResult> action)
            {
                TDoResult DoAction() => action(_action());
                return (_source != null) ? _source.Execute(DoAction) : DoAction();
            }
        }

        private class ComposableGet<TSource, TResult> : IComposable<TSource, TResult>
        {
            private readonly Func<TResult> _action;
            private readonly IComposable<TSource> _source;

            public ComposableGet(Func<TResult> action, IComposable<TSource> source)
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

            public TDoResult Execute<TDoResult>(Func<TResult, TDoResult> action)
            {
                TDoResult DoAction() => action(_action());
                return (_source != null) ? _source.Execute(DoAction) : DoAction();
            }

            public TDoResult Execute<TDoResult>(Func<TSource, TDoResult> action)
            {
                TDoResult DoAction(TSource source)
                {
                    _action();
                    return action(source);
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource, TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource source) => action(source, _action());
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default);
            }
        }

        private class ComposableGet<TSource1, TSource2, TResult> : IComposable<TSource1, TSource2, TResult>
        {
            private readonly Func<TResult> _action;
            private readonly IComposable<TSource1, TSource2> _source;

            public ComposableGet(Func<TResult> action, IComposable<TSource1, TSource2> source)
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

            public TDoResult Execute<TDoResult>(Func<TSource1, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source)
                {
                    _action();
                    return action(source);
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource2 source)
                {
                    _action();
                    return action(source);
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    _action();
                    return action(source1, source2);
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TResult, TDoResult> action)
            {
                TDoResult DoAction() => action(_action());
                return (_source != null) ? _source.Execute(DoAction) : DoAction();
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source) => action(source, _action());
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource2 source) => action(source, _action());
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2) => action(source1, source2, _action());
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default);
            }
        }

        #endregion //Private methods
    }
}
