using SolutionsPG.QuickSilver.Core.Interfaces.Disposables;

namespace SolutionsPG.QuickSilver.Core.Disposables
{

    public abstract class DisposableValue<T> : Disposable<T>, IDisposableValue<T>, IDisposableValue
    {
        #region | Public properties |

        public new T Value => base.Value;
        object IDisposableValue.Value => this.Value;

        #endregion //Public properties

        #region | Constructors |

        protected DisposableValue(T value) : base(value) { }

        #endregion //Constructors
    }
}
