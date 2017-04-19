using SolutionsPG.QuickSilver.Commons.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SolutionsPG.QuickSilver.Commons.Disposables
{

    public class TryLock : ResourceManager<bool>
    {
        #region " Variables "

        object _target;

        #endregion //Variables

        #region " Constructors "

        public TryLock(object target)
        {
            _target = target;
        }

        #endregion //Constructors

        #region " Public methods "

        #endregion //Public methods

        #region " Protected methods "

        protected override bool AcquireImpl()
        {
            bool hasLocked = Monitor.TryEnter(_target, TimeSpan.FromSeconds(10));
            if (!hasLocked) throw new Exception();
            return hasLocked;
        }

        protected override void ReleaseImpl(bool hasLocked)
        {
            if (hasLocked)
                Monitor.Exit(_target);
        }

        #endregion //Protected methods
    }
}
