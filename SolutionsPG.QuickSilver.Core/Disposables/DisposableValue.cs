using System;
using SolutionsPG.QuickSilver.Core.Helpers;
using SolutionsPG.QuickSilver.Core.Interfaces.Disposables;

namespace SolutionsPG.QuickSilver.Core.Disposables
{

    public abstract class DisposableValue<T> : IDisposableValue<T>, IDisposableValue, IDisposable
    {
        #region " Variables "

        IDisposable _disposableHelper;

        #endregion //Variables

        #region " Public properties "

        public T Value { get; }
        object IDisposableValue.Value => this.Value;

        #endregion //Public properties

        #region " Constructors "

        protected DisposableValue(T value)
        {
            _disposableHelper = new DisposableHelper(Dispose_);
            this.Value = value;

            void Dispose_() => this.DisposeImpl(this.Value);
        }

        #endregion //Constructors

        #region " Public methods "

        void IDisposable.Dispose()
        {
            _disposableHelper.Dispose();
        }

        #endregion //Public methods

        #region " Protected methods "

        protected abstract void DisposeImpl(T value);

        #endregion //Protected methods
    }
}
