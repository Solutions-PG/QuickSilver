using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static IComposable<TSource> Apply<TSource>(this IComposable<TSource> obj, Action<TSource> action)
        {
            return new ComposableApply<TSource>(action, obj);
        }

        public static IComposable<TSource1, TSource2> Apply<TSource1, TSource2>(this IComposable<TSource1, TSource2> obj, Action<TSource1, TSource2> action)
        {
            return new ComposableApply<TSource1, TSource2>(action, obj);
        }

        public static IComposable<TSource1, TSource2, TSource3> Apply<TSource1, TSource2, TSource3>(this IComposable<TSource1, TSource2, TSource3> obj, Action<TSource1, TSource2, TSource3> action)
        {
            return new ComposableApply<TSource1, TSource2, TSource3>(action, obj);
        }

        #endregion //Public methods

        #region | Private methods |

        private class ComposableApply<TSource> : IComposable<TSource>
        {
            private readonly Action<TSource> _action;
            private readonly IComposable<TSource> _source;

            public ComposableApply(Action<TSource> action, IComposable<TSource> source)
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

            public TDoResult Execute<TDoResult>(Func<TSource, TDoResult> action)
            {
                TDoResult DoAction(TSource source)
                {
                    _action(source);
                    return action(source);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource));
            }
        }

        private class ComposableApply<TSource1, TSource2> : IComposable<TSource1, TSource2>
        {
            private readonly Action<TSource1, TSource2> _action;
            private readonly IComposable<TSource1, TSource2> _source;

            public ComposableApply(Action<TSource1, TSource2> action, IComposable<TSource1, TSource2> source)
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
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource1), default(TSource2));
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    _action(source1, source2);
                    return action(source2);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource1), default(TSource2));
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    _action(source1, source2);
                    return action(source1);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource1), default(TSource2));
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    _action(source1, source2);
                    return action(source1, source2);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource1), default(TSource2));
            }
        }

        private class ComposableApply<TSource1, TSource2, TSource3> : IComposable<TSource1, TSource2, TSource3>
        {
            private readonly Action<TSource1, TSource2, TSource3> _action;
            private readonly IComposable<TSource1, TSource2, TSource3> _source;

            public ComposableApply(Action<TSource1, TSource2, TSource3> action, IComposable<TSource1, TSource2, TSource3> source)
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

            public TDoResult Execute<TDoResult>(Func<TSource3, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action(source1, source2, source3);
                    return action(source3);
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

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource3, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action(source1, source2, source3);
                    return action(source1, source3);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TSource3, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action(source1, source2, source3);
                    return action(source2, source3);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TSource3, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action(source1, source2, source3);
                    return action(source1, source2, source3);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }
        }

        #endregion //Private methods
    }
}
