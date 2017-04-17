using System;
using SolutionsPG.QuickSilver.Commons.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers
{
    public class ResourceUnmanagedHelper<T> : ResourceUnmanaged<T>
    {
        #region " Variables "

        Action<bool, T> _disposeFunc;

        #endregion //Variables

        #region " Constructors "
        
        public ResourceUnmanagedHelper(T value, Action<bool, T> dispose) : base(value)
        {
            this._disposeFunc = dispose;
        }

        #endregion //Constructors

        #region " Protected methods "

        protected override void DisposeImpl(bool disposing, T value)
        {
            var disposeFunc = this._disposeFunc;
            if (disposeFunc == null)
                throw new NotImplementedException();
            disposeFunc(disposing, value);
        }

        #endregion //Protected methods
    }
}
