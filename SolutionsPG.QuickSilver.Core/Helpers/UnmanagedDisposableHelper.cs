using System;

using SolutionsPG.QuickSilver.Core.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
{
    public sealed class UnmanagedDisposableHelper : UnmanagedDisposable
    {
        #region | Variables |

        private readonly Action<bool> _disposeFunc;

        #endregion //Variables

        #region | Constructors |
        
        public UnmanagedDisposableHelper(Action<bool> dispose) : base()
        {
            _disposeFunc = dispose;
        }

        #endregion //Constructors

        #region | Public methods |

        protected override void DisposeImpl(bool disposing) => _disposeFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke(disposing);

        #endregion //Public methods
    }
}
