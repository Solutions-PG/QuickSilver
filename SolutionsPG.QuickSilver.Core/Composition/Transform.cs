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

        #endregion //Private methods
    }
}
