using SolutionsPG.QuickSilver.Core.Helpers;

namespace SolutionsPG.QuickSilver.Core.Disposables
{

    public abstract class ResourceManager<T, TResult>
    {
        #region | Variables |

        #endregion //Variables

        #region | Constructors |

        protected ResourceManager()
        {
        }

        #endregion //Constructors

        #region | Public methods |

        public DisposableValue<TResult> Acquire(T obj)
        {
            return new DisposableValueHelper<TResult>(this.AcquireImpl(obj), this.ReleaseImpl);
        }

        #endregion //Public methods

        #region | Protected methods |

        protected abstract TResult AcquireImpl(T obj);
        protected abstract void ReleaseImpl(TResult value);

        #endregion //Protected methods
    }
}
