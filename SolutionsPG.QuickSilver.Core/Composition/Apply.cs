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

        #endregion //Private methods
    }
}
