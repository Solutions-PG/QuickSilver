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

        public static IComposable<TSource> Do<TSource>(this IComposable<TSource> obj, Action action)
        {
            return new ComposableDo<TSource>(action, obj);
        }

        public static IComposable<TSource1, TSource2> Do<TSource1, TSource2>(this IComposable<TSource1, TSource2> obj, Action action)
        {
            return new ComposableDo<TSource1, TSource2>(action, obj);
        }

        public static IComposable<TSource1, TSource2, TSource3> Do<TSource1, TSource2, TSource3>(this IComposable<TSource1, TSource2, TSource3> obj, Action action)
        {
            return new ComposableDo<TSource1, TSource2, TSource3>(action, obj);
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

        private class ComposableDo<TSource1, TSource2> : IComposable<TSource1, TSource2>
        {
            private readonly Action _action;
            private readonly IComposable<TSource1, TSource2> _source;

            public ComposableDo(Action action, IComposable<TSource1, TSource2> source)
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
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource1));
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource2 source)
                {
                    _action();
                    return action(source);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource2));
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    _action();
                    return action(source1, source2);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default(TSource1), default(TSource2));
            }
        }

        private class ComposableDo<TSource1, TSource2, TSource3> : IComposable<TSource1, TSource2, TSource3>
        {
            private readonly Action _action;
            private readonly IComposable<TSource1, TSource2, TSource3> _source;

            public ComposableDo(Action action, IComposable<TSource1, TSource2, TSource3> source)
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

            public TDoResult Execute<TDoResult>(Func<TSource3, TDoResult> action)
            {
                TDoResult DoAction(TSource3 source)
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

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource3, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource3 source3)
                {
                    _action();
                    return action(source1, source3);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TSource3, TDoResult> action)
            {
                TDoResult DoAction(TSource2 source2, TSource3 source3)
                {
                    _action();
                    return action(source2, source3);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TSource3, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2, TSource3 source3)
                {
                    _action();
                    return action(source1, source2, source3);
                }
                return (_source != null) ? _source.Execute(DoAction) : DoAction(default, default, default);
            }
        }
        #endregion //Private methods
    }
}
