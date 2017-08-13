﻿using System;
using System.Collections.Generic;

namespace SolutionsPG.QuickSilver.Core.Disposables
{
    public abstract class Disposable : IDisposable
    {
        #region " Variables "

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool _disposedValue = false;

        #endregion //Variables

        #region " Constructors "

        protected Disposable()
        {

        }

        #endregion //Constructors

        #region " Public methods "

        void IDisposable.Dispose()
        {
            if (!_disposedValue)
            {
                this.DisposeImpl();
                _disposedValue = true;
            }
        }

        #endregion //Public methods

        #region " Protected methods "

        protected abstract void DisposeImpl();

        #endregion //Protected methods
    }
}