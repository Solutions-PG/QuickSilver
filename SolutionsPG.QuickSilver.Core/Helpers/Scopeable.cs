using SolutionsPG.QuickSilver.Core.Exceptions;
using System;

namespace SolutionsPG.QuickSilver.Core.Disposables
{
    public struct Scopeable : IDisposable
    {
        #region | Variables |

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Action called when disposing
        /// </summary>
        private readonly Action _disposeFunc;

        #endregion //Variables

        #region | Constructors |

        public Scopeable(Action dispose)
        {
            _disposed = false;
            _disposeFunc = dispose.ThrowIfArgumentNull(nameof(dispose));
        }

        #endregion //Constructors

        #region | Public methods |

        public void Dispose()
        {
            if (_disposed == false)
            {
                _disposeFunc?.Invoke();
                _disposed = true;
            }
        }

        #endregion //Public methods
    }
}
