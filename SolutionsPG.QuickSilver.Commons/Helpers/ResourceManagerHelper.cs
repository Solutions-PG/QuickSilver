using System;
using SolutionsPG.QuickSilver.Commons.Disposables;

namespace SolutionsPG.QuickSilver.Commons.Helpers
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

        protected override T AcquireImpl()
        {
            var impl = _acquireFunc;
            if (impl == null)
                throw new NotImplementedException();
            return impl();
        }

        protected override void ReleaseImpl(T value)
        {
            var impl = _releaseFunc;
            if (impl == null)
                throw new NotImplementedException();
            impl(value);
        }

        #endregion //Protected methods
    }
}
