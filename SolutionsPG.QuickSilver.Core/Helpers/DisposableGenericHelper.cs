using System;

using SolutionsPG.QuickSilver.Core.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
{
    public sealed class DisposableHelper<T> : Disposable<T>
    {
        #region | Variables |

        private readonly Action<T> _disposeFunc;

        #endregion //Variables

        #region | Constructors |

        public DisposableHelper(T value, Action<T> dispose) : base(value)
        {
            _disposeFunc = dispose.ThrowIfArgumentNull(nameof(dispose));
        }

        #endregion //Constructors

        #region | Protected methods |

        protected override void DisposeImpl(T value) => _disposeFunc(value);

        #endregion //Protected methods
    }
}
