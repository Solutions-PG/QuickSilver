using SolutionsPG.QuickSilver.Commons.Helpers;
using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Commons.Disposables
{

    public abstract class ResourceManager<T>
    {
        #region " Variables "

        #endregion //Variables

        #region " Constructors "

        protected ResourceManager()
        {
        }

        #endregion //Constructors

        #region " Public methods "

        public DisposableValue<T> Acquire()
        {
            return new DisposableValueHelper<T>(this.AcquireImpl(), this.ReleaseImpl);
        }

        #endregion //Public methods

        #region " Protected methods "

        protected abstract T AcquireImpl();
        protected abstract void ReleaseImpl(T value);

        #endregion //Protected methods
    }
}
