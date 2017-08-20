using System;
using System.Threading;
using System.Threading.Tasks;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Async
{
    /// <summary>
    /// Contains extensions related to async operations
    /// </summary>
    /// <remarks>
    /// Added AwaitSync mostly as an experiment to synchronously get result in UI and ASP thread without deadlocking.
    /// Probably the next best thing after managing your own SynchronisationContext, which is not recommended either.
    /// </remarks>
    public static partial  class AsyncEx
    {
        #region | Public methods |

        /// <summary>
        /// Allow to synchronously get an async result in UI and ASP thread without deadlocking.
        /// Probably the next best thing after managing your own SynchronisationContext, which is not recommended either.
        /// 
        /// Under the cover, the action is run as a new task which is then waited synchronously.
        /// </summary>
        /// <param name="action">An asynchronous action we want to wait for.</param>
        /// <exception cref="ArgumentNullException">When the action value is null</exception>
        public static void AwaitSync(this Func<Task> action) => action.ThrowIfArgumentNull(nameof(action)).AwaitSync_();

        /// <summary>
        /// Allow to synchronously get an async result in UI and ASP thread without deadlocking.
        /// Probably the next best thing after managing your own SynchronisationContext, which is not recommended either.
        /// 
        /// Under the cover, the action is run as a new task which is then waited synchronously.
        /// </summary>
        /// <typeparam name="TResult">Type of the expected result</typeparam>
        /// <param name="action">An asynchronous action we want to wait for.</param>
        /// <returns>The result retuned by the action</returns>
        public static TResult AwaitSync<TResult>(this Func<Task<TResult>> action) => action.ThrowIfArgumentNull(nameof(action)).AwaitSync_();

        /// <summary>
        /// Allow to synchronously get an async result in UI and ASP thread without deadlocking.
        /// Probably the next best thing after managing your own SynchronisationContext, which is not recommended either.
        /// 
        /// Under the cover, the action is run in a new thread, to avoid polluting the ThreadPool with the thread static
        /// values and to prevent others to change them.  The task is then waited synchronously. Please note that it's
        /// not a single context since as soon as an await is encountered, the thread will complete and the remaining of
        /// the task will run on the ThreadPool and the thread static will be lost again. So if you need it, make sur to
        /// keep any copy from them before the first await.
        /// </summary>
        /// <param name="action">An asynchronous action we want to wait for.</param>
        /// <param name="configureThreadStatic">LLet the user</param>
        /// <exception cref="ArgumentNullException">When the action value is null</exception>
        public static void AwaitSync(this Func<Task> action, Action configureThreadStatic)
        {
            action.ThrowIfArgumentNull(nameof(action));
            configureThreadStatic.ThrowIfArgumentNull(nameof(configureThreadStatic));

            action.AwaitSync_(configureThreadStatic);
        }


        /// <summary>
        /// Allow to synchronously get an async result in UI and ASP thread without deadlocking.
        /// Probably the next best thing after managing your own SynchronisationContext, which is not recommended either.
        /// 
        /// Under the cover, the action is run in a new thread, to avoid polluting the ThreadPool with the thread static
        /// values and to prevent others to change them.  The task is then waited synchronously. Please note that it's
        /// not a single context since as soon as an await is encountered, the thread will complete and the remaining of
        /// the task will run on the ThreadPool and the thread static will be lost again. So if you need it, make sur to
        /// keep any copy from them before the first await.
        /// </summary>
        /// <typeparam name="TResult">Type of the expected result</typeparam>
        /// <param name="action">An asynchronous action we want to wait for.</param>
        /// <param name="configureThreadStatic">LLet the user</param>
        /// <exception cref="ArgumentNullException">When the action value is null</exception>
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
