using System;
using SolutionsPG.QuickSilver.Core.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
{
    public sealed class ResourceManagerHelper<T> : ResourceManager<T>
    {
        #region " Variables "

        Func<T> _acquireFunc;
        Action<T> _releaseFunc;

        #endregion //Variables

        #region " Constructors "

        public ResourceManagerHelper(Func<T> acquire, Action<T> release) : base()
        {
            _acquireFunc = acquire;
            _releaseFunc = release;
        }

        #endregion //Constructors

        #region " Protected methods "

        protected override T AcquireImpl() => _acquireFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke();

        protected override void ReleaseImpl(T value) => _releaseFunc.ThrowIfNull(_ => new NotImplementedException()).Invoke(value);

        #endregion //Protected methods
    }
}
