using System;

using SolutionsPG.QuickSilver.Core.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
{
    public sealed class DisposableHelper : Disposable
    {
        #region | Variables |

        private readonly Action _disposeFunc;

        #endregion //Variables

        #region | Constructors |
        
        public DisposableHelper(Action dispose) : base()
        {
            _disposeFunc = dispose.ThrowIfArgumentNull(nameof(dispose));
        }

        #endregion //Constructors

        #region | Public methods |

        protected override void DisposeImpl() => _disposeFunc();

        #endregion //Public methods
    }
}
