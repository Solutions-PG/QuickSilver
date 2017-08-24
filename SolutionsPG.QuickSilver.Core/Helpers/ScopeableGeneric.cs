using System;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Disposables
{
    public struct Scopeable<T> : IDisposable
    {
        #region | Variables |

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Value used with disposeFunc
        /// </summary>
        private readonly T _value;

        /// <summary>
        /// Action called when disposing
        /// </summary>
        private readonly Action<T> _disposeFunc;

        #endregion //Variables

        #region | Constructors |

        public Scopeable(T value, Action<T> dispose)
        {
            _disposed = false;
            _value = value;
            _disposeFunc = dispose.ThrowIfArgumentNull(nameof(dispose));
        }

        #endregion //Constructors

        #region | Public methods |

        public void Dispose()
        {
            if (_disposed == false)
            {
                _disposeFunc(_value);
                _disposed = true;
            }
        }

        #endregion //Public methods
    }
}
