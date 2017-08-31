using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static IComposable<T> AsComposable<T>(this T obj)
        {
            return (obj as IComposable<T>) ?? new ComposableObj<T>(obj, null);
        }

        #endregion //Public methods

        #region | Private methods |

        private class ComposableObj<T> : IComposable<T>
        {
            private readonly T _obj;
            private readonly IComposable _source;

            public ComposableObj(T obj, IComposable source)
            {
                _obj = obj;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                return _source != null ? _source.Execute(action) : action();
            }

            public TDoResult Execute<TDoResult>(Func<T, TDoResult> action)
            {
                if (_source != null)
                {
                    TDoResult DoAction() => action(_obj);
                    return _source.Execute(DoAction);
                }
                return action(_obj);
            }
        }

        #endregion //Private methods
    }
}
