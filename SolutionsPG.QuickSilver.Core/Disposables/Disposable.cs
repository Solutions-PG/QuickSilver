using System;

namespace SolutionsPG.QuickSilver.Core.Disposables
{
    public abstract class Disposable : IDisposable
    {
        #region | Variables |

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        protected bool Disposed {get; private set;}

        #endregion //Variables

        #region | Constructors |

        protected Disposable()
        {
            Disposed = false;
        }

        #endregion //Constructors

        #region | Public methods |

        void IDisposable.Dispose()
        {
            if (this.Disposed == false)
            {
                this.DisposeImpl();
                this.Disposed = true;
            }
        }

        #endregion //Public methods

        #region | Protected methods |

        protected abstract void DisposeImpl();

        #endregion //Protected methods
    }
}
