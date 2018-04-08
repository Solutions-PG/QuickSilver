using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static IComposable<TResult> Transform<TSource, TResult>(this IComposable<TSource> obj, Func<TSource, TResult> action)
        {
            return new ComposableTransform<TSource, TResult>(action, obj);
        }

        //public static IComposable<TSource1, TResult> Transform<TSource1, TSource2, TResult>(this IComposable<TSource1, TSource2> obj, Func<TSource1, TResult> action)
        //{
        //    return new ComposableTransform<TSource1, TResult>(action, obj);
        //}

        public static IComposable<TSource1, TResult> Transform<TSource1, TSource2, TResult>(this IComposable<TSource1, TSource2> obj, Func<TSource1, TSource2, TResult> action)
        {
            return new ComposableTransform<TSource1, TSource2, TResult>(action, obj);
        }

        public static IComposable<TSource1, TSource2, TResult> Transform<TSource1, TSource2, TSource3, TResult>(this IComposable<TSource1, TSource2, TSource3> obj, Func<TSource1, TSource2, TSource3, TResult> action)
        {
            return new ComposableTransform<TSource1, TSource2, TSource3, TResult>(action, obj);
        }

        #endregion //Public methods

        #region | Private methods |

        private class ComposableTransform<TSource, TResult> : IComposable<TResult>
        {
            private readonly Func<TSource, TResult> _action;
            private readonly IComposable<TSource> _source;

            public ComposableTransform(Func<TSource, TResult> action, IComposable<TSource> source)
            {
                _action = action;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                TDoResult DoAction(TSource source)
                {
                    _action(source);
                    return action();
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource));
            }

            public TDoResult Execute<TDoResult>(Func<TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource source) => action(_action(source));
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource));
            }
        }

        private class ComposableTransform<TSource1, TSource2, TResult> : IComposable<TSource1, TResult>
        {
            private readonly Func<TSource1, TSource2, TResult> _action;
            private readonly IComposable<TSource1, TSource2> _source;

            public ComposableTransform(Func<TSource1, TSource2, TResult> action, IComposable<TSource1, TSource2> source)
            {
                _action = action;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    _action(source1, source2);
                    return action();
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2) => action(_action(source1, source2));
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    _action(source1, source2);
                    return action(source1);
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2) => action(source1, _action(source1, source2));
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default);
            }
        }

        private class ComposableTransform<TSource1, TSource2, TSource3, TResult> : IComposable<TSource1, TSource2, TResult>
        {
            private readonly Func<TSource1, TSource2, TSource3, TResult> _action;
            private readonly IComposable<TSource1, TSource2, TSource3> _source;

            public ComposableTransform(Func<TSource1, TSource2, TSource3, TResult> action, IComposable<TSource1, TSource2, TSource3> source)
            {
                _action = action;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action(source1, source2, source3);
                    return action();
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action(source1, source2, source3);
                    return action(source1);
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action(source1, source2, source3);
                    return action(source2);
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action(source1, source2, source3);
                    return action(source1, source2);
                }

                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3) => action(_action(source1, source2, source3));
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3) => action(source1, _action(source1, source2, source3));
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3) => action(source2, _action(source1, source2, source3));
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TResult, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3) => action(source1, source2, _action(source1, source2, source3));
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }
        }

        #endregion //Private methods
    }
}
