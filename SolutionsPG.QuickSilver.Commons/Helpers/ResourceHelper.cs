using System;
using SolutionsPG.QuickSilver.Commons.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers
{
    public class ResourceHelper<T> : Resource<T>
    {
        #region " Variables "

        Action<T> _disposeFunc;

        #endregion //Variables

        #region " Constructors "
        
        public ResourceHelper(T value, Action<T> dispose) : base(value)
        {
            this._disposeFunc = dispose;
        }

        #endregion //Constructors

        #region " Protected methods "

        protected override void DisposeImpl(T value)
        {
            var disposeFunc = this._disposeFunc;
            if (disposeFunc == null)
                throw new NotImplementedException();
            disposeFunc(value);
        }

        #endregion //Protected methods
    }
}
