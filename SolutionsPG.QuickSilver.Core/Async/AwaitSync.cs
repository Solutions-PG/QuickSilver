using System;
using System.Threading;
using System.Threading.Tasks;
using SolutionsPG.QuickSilver.Core.Delegates;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Async
{
    /// <summary>
    /// Contains extensions related to async operations
    /// </summary>
    public static partial  class AsyncEx
    {
        #region | Public methods |

        public static void AwaitSync(this Func<Task> action) => action.ThrowIfArgumentNull(nameof(action)).AwaitSync_();

        public static TResult AwaitSync<TResult>(this Func<Task<TResult>> action) => action.ThrowIfArgumentNull(nameof(action)).AwaitSync_();

        public static void AwaitSync(this Func<Task> action, Action configureThreadStatic)
        {
            action.ThrowIfArgumentNull(nameof(action));
            configureThreadStatic.ThrowIfArgumentNull(nameof(configureThreadStatic));

            action.AwaitSync_(configureThreadStatic);
        }

        public static TResult AwaitSync<TResult>(this Func<Task<TResult>> action, Action configureThreadStatic)
        {
            action.ThrowIfArgumentNull(nameof(action));
            configureThreadStatic.ThrowIfArgumentNull(nameof(configureThreadStatic));

            return action.AwaitSync_(configureThreadStatic);
        }

        #endregion //Public methods

        #region | Private methods |

        private static void AwaitSync_(this Func<Task> action) => Task.Run(action).GetAwaiter().GetResult();

        private static TResult AwaitSync_<TResult>(this Func<Task<TResult>> action) => Task.Run(action).GetAwaiter().GetResult();

        private static void AwaitSync_(this Func<Task> action, Action configureThreadStatic)
        {
            Task TaskRun()
            {
                try { configureThreadStatic(); return action(); }
                catch (Exception exception) { return Task.FromException(exception); }
            }

            RunInThreadAndWait_(TaskRun).GetAwaiter().GetResult();
        }

        private static TResult AwaitSync_<TResult>(this Func<Task<TResult>> action, Action configureThreadStatic)
        {
            Task<TResult> TaskRun()
            {
                try { configureThreadStatic(); return action(); }
                catch (Exception exception) { return Task.FromException<TResult>(exception); }
            }

            return RunInThreadAndWait_(TaskRun).GetAwaiter().GetResult();
        }

        private static TTask RunInThreadAndWait_<TTask>(this Func<TTask> action) where TTask : Task
        {
            var result = default(TTask);

            void ThreadStart() => result = action();
            var myThread = new Thread(ThreadStart);
            myThread.Start();
            myThread.Join();

            return result;
        }

        #endregion //Private methods
    }
}
