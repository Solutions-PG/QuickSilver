using System;
using SolutionsPG.QuickSilver.Core.Disposables;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Helpers
{
    public sealed class ResourceManagerHelper<T, TResult> : ResourceManager<T, TResult>
    {
        #region | Variables |

        private readonly Func<T, TResult> _acquireFunc;
        private readonly Action<TResult> _releaseFunc;

        #endregion //Variables

        #region | Constructors |

        public ResourceManagerHelper(Func<T, TResult> acquire, Action<TResult> release) : base()
        {
            acquire.ThrowIfArgumentNull(nameof(acquire));
            release.ThrowIfArgumentNull(nameof(release));

            _acquireFunc = acquire;
            _releaseFunc = release;
        }

        #endregion //Constructors

        #region | Protected methods |

        protected override TResult AcquireImpl(T obj) => _acquireFunc(obj);

        protected override void ReleaseImpl(TResult value) => _releaseFunc(value);

        #endregion //Protected methods
    }
}
