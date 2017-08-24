using SolutionsPG.QuickSilver.Core.Helpers;
using System;
using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Interfaces.Disposables;

namespace SolutionsPG.QuickSilver.Core.Disposables
{

    public abstract class UnmanagedDisposableValue<T> : UnmanagedDisposable<T>, IDisposableValue<T>, IDisposableValue
    {
        #region | Variables |

        public new T Value => base.Value;
        object IDisposableValue.Value => this.Value;

        #endregion //Variables

        #region | Constructors |

        protected UnmanagedDisposableValue(T value) : base(value)
        {
        }

        #endregion //Constructors
    }
}
