using System;

namespace SolutionsPG.QuickSilver.Core.Disposables
{
    public abstract class UnmanagedDisposable<T> : UnmanagedDisposable
    {
        #region | Variables |

        /// <summary>
        /// Value used with DisposeImpl
        /// </summary>
        protected T Value { get; }

        #endregion //Variables

        #region | Constructors |

        protected UnmanagedDisposable(T value) : base()
        {
            this.Value = value;
        }

        #endregion //Constructors

        #region | Protected methods |

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing">
        /// If false, only dispose of unmanaged resources and set large fields to null. If true, it indicate that it is
        /// also appropriate to dispose of managed object.
        /// </param>
        protected sealed override void DisposeImpl(bool disposing) => this.DisposeImpl(disposing, this.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing">
        /// If false, only dispose of unmanaged resources and set large fields to null. If true, it indicate that it is
        /// also appropriate to dispose of managed object.
        /// </param>
        /// <param name="value"></param>
        protected abstract void DisposeImpl(bool disposing, T value);

        #endregion //Protected methods
    }
}
