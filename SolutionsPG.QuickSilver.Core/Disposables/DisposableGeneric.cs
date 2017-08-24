namespace SolutionsPG.QuickSilver.Core.Disposables
{
    public abstract class Disposable<T> : Disposable
    {
        #region | Variables |

        /// <summary>
        /// Value used with DisposeImpl
        /// </summary>
        protected T Value {get; private set;}

        #endregion //Variables

        #region | Constructors |

        protected Disposable(T value) : base()
        {
            Value = value;
        }

        #endregion //Constructors

        #region | Protected methods |

        protected sealed override void DisposeImpl() => DisposeImpl(this.Value);
        protected abstract void DisposeImpl(T value);

        #endregion //Protected methods
    }
}
