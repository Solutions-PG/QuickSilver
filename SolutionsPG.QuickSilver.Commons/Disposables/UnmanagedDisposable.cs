using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Commons.Disposables
{
    public abstract class UnmanagedDisposable : IDisposable
    {
        #region " Variables "

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool _disposedValue = false;

        #endregion //Variables

        #region " Constructors "

        protected UnmanagedDisposable()
        {

        }

        #endregion //Constructors

        #region " Finalizer "

        ~UnmanagedDisposable() => this.Dispose(false);

        #endregion //Constructors

        #region " Public methods "

        void IDisposable.Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion //Public methods

        #region " Protected methods "

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing">
        /// If false, only dispose of unmanaged resources and set large fields to null. If true, it indicate that it is
        /// also appropriate to dispose of managed object.
        /// </param>
        protected abstract void DisposeImpl(bool disposing);

        #endregion //Protected methods

        #region " Private methods "

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                this.DisposeImpl(disposing);
                _disposedValue = true;
            }
        }

        #endregion //Private methods
    }
}
