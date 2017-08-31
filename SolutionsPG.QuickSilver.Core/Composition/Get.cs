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

        #endregion //Private methods
    }
}
