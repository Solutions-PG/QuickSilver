using System;
using System.Threading;

namespace SolutionsPG.QuickSilver.Core.Disposables
{

    public class TryLock : ResourceManager<object, bool>
    {
        #region | Variables |

        private readonly object _target;

        #endregion //Variables

        #region | Constructors |

        public TryLock(object target)
        {
            _target = target;
        }

        #endregion //Constructors

        #region | Public methods |

        #endregion //Public methods

        #region | Protected methods |

        protected override bool AcquireImpl(object obj)
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
